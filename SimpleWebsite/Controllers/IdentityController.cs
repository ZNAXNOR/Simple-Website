using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleWebsite.Models;
using SimpleWebsite.ViewModels.IdentityViewModel;

namespace SimpleWebsite.Controllers
{
    public class IdentityController : Controller
    {
        private readonly SignInManager<AppUserModel> _signInManager;
        private readonly UserManager<AppUserModel> _userManager;

        public IdentityController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                     loginVM.Username!, loginVM.Password!, loginVM.RememberMe, false
                );

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt!");
                    return View(loginVM);
                }
            }
            return View(loginVM);
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUserModel appUser = new AppUserModel()
                {
                    Name = registerVM.Name,
                    UserName = registerVM.Email,
                    Email = registerVM.Email,
                };

                var result = await _userManager.CreateAsync(appUser, registerVM.Password!);
                                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerVM);
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

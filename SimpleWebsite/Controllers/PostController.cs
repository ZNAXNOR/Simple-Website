using Microsoft.AspNetCore.Mvc;

namespace SimpleWebsite.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

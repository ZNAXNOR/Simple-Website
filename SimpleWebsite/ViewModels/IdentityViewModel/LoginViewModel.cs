using System.ComponentModel.DataAnnotations;

namespace SimpleWebsite.ViewModels.IdentityViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

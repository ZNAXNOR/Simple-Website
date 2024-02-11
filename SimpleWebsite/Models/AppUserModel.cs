using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SimpleWebsite.Models
{
    public class AppUserModel : IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}

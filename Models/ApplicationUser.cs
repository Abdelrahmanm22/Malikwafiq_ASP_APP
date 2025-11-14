using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Malek_wafik.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public bool IsAgree { get; set; }
    }
}

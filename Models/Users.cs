using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class Users:IdentityUser
    {
        [Display(Name = "NickName")]
        [Required]
        public string? Dis_Name { get; set; }
        [Display(Name = "UserImage")]
        
        public string? User_image { get; set; }
        public bool IsDelete { get; set; }
    }
}

using Kazanola.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class AccountViewModel
    {
        public string? id { get; set; }
        [Required]

        public string? email { get; set; }
        [Required]
        public string? username { get; set; }
        
        public string? user_image { get; set; }
        public IFormFile? File { get; set; }
        public string? PassWord { get; set; }
        public List<Users>? users { get; set; }
    }
}

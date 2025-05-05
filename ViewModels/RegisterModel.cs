using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? PassWord { get; set; }
        [Required]
        [Compare("PassWord", ErrorMessage = "Password Not Confirm")]
        public String? ComfirmPassword { get; set; }
        public string? UserName { get; set; }
        public string? User_image { get; set; }
        public IFormFile? File { get; set; }



    }
}

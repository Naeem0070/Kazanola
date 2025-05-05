using System.ComponentModel.DataAnnotations;

namespace Kazanola  .ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email in Required")]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "Password in Required")]
        [DataType(DataType.Password)]

        public string PassWord { get; set; }
        public bool RememberMe { get; set; }



    }
}

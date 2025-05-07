using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class ContactUsForm: BaseEntity,IbaseEntity
    {
        [Key]
        public int ContactUsFormId { get; set; }
        [NotMapped]
        public int Id => ContactUsFormId;
        [Required]
        [Display(Name = "الاسم")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "البريد الالكتروني")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "رقم الهاتف")]
        public string? PhoneNumber { get; set; }
        [Required]
        [Display(Name = "الرسالة")]
        public string? Message { get; set; }
 
    }
}

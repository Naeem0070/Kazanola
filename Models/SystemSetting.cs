using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class SystemSetting: BaseEntity,IbaseEntity
    {
        [Key]
        public int SystemSettingId { get; set; }
        [NotMapped]
        public int Id => SystemSettingId;
        [Required]
        [Display(Name = "Logo")]
        public string? LogoUrl { get; set; }
        [Required]
        [Display(Name = "الموقع")]
        public string? Location { get; set; }
        [Required]
        [Display(Name = "رقم الهاتف")]
        public string? PhomeNumber { get; set; }
        [Required]
        [Display(Name = "البريد الالكتروني")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "رسالة تعريفية في الفووتر")]
        public string? FooterNote { get; set; }
    }
}

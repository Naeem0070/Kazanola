using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class SystemSetting: BaseEntity
    {
        public int SystemSettingId { get; set; }
        public override int Id => SystemSettingId;
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

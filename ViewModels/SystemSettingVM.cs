using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class SystemSettingVM:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SystemSettingId { get; set; }
        [NotMapped]
        public override int Id => SystemSettingId;

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
        [Display(Name = "Logo")]
        public IFormFile? LogoFile { get; set; }
        public List<SystemSetting>? ListOfSetting { get; set; }
    }
}

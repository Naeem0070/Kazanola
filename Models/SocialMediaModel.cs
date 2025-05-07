using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class SocialMediaModel: BaseEntity
    {
        public int SocialMediaId { get; set; }
        public override int Id => SocialMediaId;
        [Required]
        [Display(Name = "اسم المنصة")]
        public string? PlatformName { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? Link { get; set; }
        [Required]
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }

    }
}

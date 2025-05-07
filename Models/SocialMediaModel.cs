using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class SocialMediaModel: BaseEntity,IbaseEntity
    {
        [Key]
        public int SocialMediaId { get; set; }
        [NotMapped]
        public int Id => SocialMediaId;
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

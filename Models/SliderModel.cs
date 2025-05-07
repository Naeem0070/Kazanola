using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class SliderModel:BaseEntity
    {
        public int SliderModelId { get; set; }
        public override int Id => SliderModelId;
        [Required]
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? ButtonsLink { get; set; }
    }
}

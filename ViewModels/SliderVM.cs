using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class SliderVM:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SliderModelId { get; set; }
        [NotMapped]
        public override int Id => SliderModelId;
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile? ImageFile { get; set; }
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? ButtonsLink { get; set; }
        public List<SliderModel>? ListOfSlider { get; set; }
    }
}

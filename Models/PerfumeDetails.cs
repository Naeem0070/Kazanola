using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class PerfumeDetails:BaseEntity
    {
        public int PerfumeDetailsId { get; set; }
        public override int Id => PerfumeDetailsId;
        [Required]
        [Display(Name = "العطر")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? ProductDiscreption { get; set; }
        [Required]
        [Display(Name = "الصورة1")]
        public string? ProductImage1 { get; set; }
        [Required]
        [Display(Name = "الصورة2")]
        public string? ProductImage2 { get; set; }
        [Required]
        [Display(Name = "الصورة3")]
        public string? ProductImage3 { get; set; }
        [Required]
        [Display(Name = "الصورة4")]
        public string? ProductImage4 { get; set; }
        [Required]
        [Display(Name = "الصورة5")]
        public string? ProductImage5 { get; set; }
        [Required]
        [Display(Name = "الصورة6")]
        public string? ProductImage6 { get; set; }
        public Product? product { get; set; }
    }
}

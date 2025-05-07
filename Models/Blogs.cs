using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class Blogs:BaseEntity
    {
        public int BlogsId { get; set; }
        public override int Id => BlogsId;
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "لمقدمة")]
        public string? StartOfBolg { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "الخاتمة")]
        public string? EndOfBolg { get; set; }
        [Required]
        [Display(Name = "الصورة1")]
        public string? ImageUrl1 { get; set; } 
        [Required]
        [Display(Name = "2الصورة")]
        public string? ImageUrl2 { get; set; }
        [Required]
        [Display(Name = "تاريخ النشر")]
        public DateTime PublishedDate { get; set; }
        [Required]
        [Display(Name = "اسم الكاتب")]
        public string? WhoIsTheWriter { get; set; }
    }
}

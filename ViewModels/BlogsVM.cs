using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class BlogsVM:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogsId { get; set; }
        [NotMapped]
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
        
        [Display(Name = "الصورة1")]
        public string? ImageUrl1 { get; set; }
     
        [Display(Name = "2الصورة")]
        public string? ImageUrl2 { get; set; } 
        [Display(Name = "الصورة1")]
        public IFormFile? FileUrl1 { get; set; }
     
        [Display(Name = "2الصورة")]
        public IFormFile? FileUrl2 { get; set; }
        [Required]
        [Display(Name = "تاريخ النشر")]
        public DateTime PublishedDate { get; set; }
        [Required]
        [Display(Name = "اسم الكاتب")]
        public string? WhoIsTheWriter { get; set; }
        public List<Blogs>? ListOfBlogs { get; set; }
    }
}

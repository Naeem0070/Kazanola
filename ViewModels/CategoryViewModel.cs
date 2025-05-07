using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class CategoryViewModel:BaseEntity
    {
        public int CategoryID { get; set; }
        [Required]
        [Display(Name = "الصنف")]
        public string? CategoryName { get; set; }
        [Display(Name = "الصورة")]
        public int? ImageUrl { get; set; }
        
        [Display(Name ="ملف الصورة")]
        public IFormFile? ImageFile { get; set; }
        public List<Category>? CategoryList { get; set; }
    }
}

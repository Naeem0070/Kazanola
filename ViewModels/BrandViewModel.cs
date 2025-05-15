using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class BrandViewModel:BaseEntity
    {
        public int BrandId { get; set; }
        [Required]
        [Display(Name = "اسم البراند")]
        public string? BrandName { get; set; }
        public Category? Category { get; set; }
        [Required]
        [Display(Name = "الصنف")]

        public int CategoryId { get; set; }
        public List<Brand>? BrandList { get; set; }
        public List<Category>? CategoryList { get; set; }
    }
}

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
        public List<Category>? CategoryList { get; set; }
    }
}

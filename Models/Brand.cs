using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public partial class Brand:BaseEntity
    {
        public int BrandId { get; set; }
        [Required]
        [Display(Name = "اسم البراند")]
        public string? BrandName { get; set; }
        public Category? Category { get; set; }
        [Required]
        [Display(Name = "الصنف")]

        public int CategoryId { get; set; }
    }
}

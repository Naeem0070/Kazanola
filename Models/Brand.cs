using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public partial class Brand: BaseEntity, IbaseEntity
    {
        
        public int BrandId { get; set; }
        [NotMapped]
        public int Id => BrandId;
        [Required]
        [Display(Name = "اسم البراند")]
        public string? BrandName { get; set; }
        public Category? Category { get; set; }
        [Required]
        [Display(Name = "الصنف")]

        public int CategoryId { get; set; }
    }
}

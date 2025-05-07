using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class WhoWeAreModel:BaseEntity,IbaseEntity
    {
        [Key]
        public int WhoWeAreId { get; set; }
        [NotMapped]
        public int Id => WhoWeAreId;
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? ButtonUrl { get; set; }
        
    }
}

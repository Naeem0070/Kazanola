using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class WhoWeAreVM:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WhoWeAreId { get; set; }
        [NotMapped]
        public override int Id => WhoWeAreId;
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? ButtonUrl { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile? ImageFile { get; set; }
        public List<WhoWeAreModel>? ListofWe { get; set; }
    }
}

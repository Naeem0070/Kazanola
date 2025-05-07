using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class FadeBack: BaseEntity
    {
        public int FadeBackId { get; set; }
        public override int Id => FadeBackId;
        [Required]
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "الاسم")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "الحالة")]
        public string? Situet { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
       
    
    }
}

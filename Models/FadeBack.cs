using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class FadeBack: BaseEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FadeBackId { get; set; }
        [NotMapped]
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

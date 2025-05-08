using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class FAQModel : BaseEntity, IbaseEntity
    {
        [Key]
        public int FAQId { get; set; }
        [NotMapped]
        public int Id => FAQId;
        [Required]
        [Display(Name = "السؤال")]
        public string? Question { get; set; }
        [Required]
        [Display(Name = "الجواب")]
        public string? Answer { get; set; }
   
    }
}

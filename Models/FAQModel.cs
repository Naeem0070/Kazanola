using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class FAQModel : BaseEntity
    {
        public int FAQId { get; set; }
        public override int Id => FAQId;
        [Required]
        [Display(Name = "السؤال")]
        public string? Question { get; set; }
        [Required]
        [Display(Name = "الجواب")]
        public string? Answer { get; set; }
   
    }
}

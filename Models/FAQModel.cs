using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class FAQModel : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FAQId { get; set; }
        [NotMapped]
        public override int Id => FAQId;
        [Required]
        [Display(Name = "السؤال")]
        public string? Question { get; set; }
        [Required]
        [Display(Name = "الجواب")]
        public string? Answer { get; set; }
   
    }
}

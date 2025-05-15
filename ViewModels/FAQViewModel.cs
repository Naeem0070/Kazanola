using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kazanola.Models;

namespace Kazanola.ViewModels
{
    public class FAQViewModel:BaseEntity
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
        public List<FAQModel>? FAQList { get; set; }
    }
}

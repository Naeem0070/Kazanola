using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class Terms_ConditionsModel : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Terms_ConditionsId { get; set; }
        [NotMapped]
        public  override int Id => Terms_ConditionsId;
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
       
    
    }
}

using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class Terms_ConditionsModel : BaseEntity
    {
        public int Terms_ConditionsId { get; set; }
        public override int Id => Terms_ConditionsId;
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
       
    
    }
}

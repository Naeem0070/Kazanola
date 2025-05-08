using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class AdsPanelsModel: BaseEntity, IbaseEntity
    {
        [Key]
        public int AdsPanelsModelId { get; set; }
        [NotMapped]
        public int Id => AdsPanelsModelId;
        [Required]
        [Display(Name = "العنوان")]
        public string? title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? description { get; set; }
        [Required]
        [Display(Name = "ميديا")]
        public string? MediaUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class AdsPanelsModel:BaseEntity
    {
        public int AdsPanelsModelId { get; set; }
        public override int Id => AdsPanelsModelId;
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

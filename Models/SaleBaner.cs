using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class SaleBaner: BaseEntity, IbaseEntity
    {
        [Key]
        public int SaleBanerId { get; set; }
        [NotMapped]
        public int Id => SaleBanerId;

        [Required]
        [Display(Name="العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "السعر")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "المدة")]
        public DateTime FeaturedUntil { get; set; }
        [Required]
        [Display(Name = "الوصف2")]
        public string? PromotionalText { get; set; }
        [Required]
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "هل هو فعال")]
        public bool IsFeatured { get; set; }

    }
}

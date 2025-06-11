using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class SaleBanerVM:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleBanerId { get; set; }
        [NotMapped]
        public override int Id => SaleBanerId;

        [Required]
        [Display(Name = "العنوان")]
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
      
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile? ImageFile { get; set; }
        [Required]
        [Display(Name = "هل هو فعال")]
        public bool IsFeatured { get; set; }
        public List<SaleBaner>? SaleBanerList { get; set; }
    }
}

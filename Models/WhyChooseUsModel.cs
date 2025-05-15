using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class WhyChooseUsModel: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WhyChooseUsId { get; set; }
        [NotMapped]
        public override int Id => WhyChooseUsId;
        [Required]
        [Display(Name = "العنوان")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "1الصورة")]
        public string? ImageUrl1 { get; set; }
        [Display(Name = "الصورة2")]
        public string? ImageUrl2 { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? ButtonUrl { get; set; }

    }
}

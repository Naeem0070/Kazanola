using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class SocialMediaVM:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SocialMediaId { get; set; }
        [NotMapped]
        public override int Id => SocialMediaId;
        [Required]
        [Display(Name = "اسم المنصة")]
        public string? PlatformName { get; set; }
        [Required]
        [Display(Name = "الرابط")]
        public string? Link { get; set; }
        
        [Display(Name = "الصورة")]
        public string? ImageUrl { get; set; }
         
        [Display(Name = "الصورة")]
        public IFormFile? ImageFile { get; set; }
        public List<SocialMediaModel>? ListOfSocial { get; set; }

    }
}

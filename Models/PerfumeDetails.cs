using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class PerfumeDetails: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerfumeDetailsId { get; set; }
        [NotMapped]
        public override int Id => PerfumeDetailsId;
        [Required]
        [Display(Name = "العطر")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? ProductDiscreption { get; set; }
        [Required]
        [Display(Name = "النوع")]
        public string? ProductType { get; set; }

        
       
        [Display(Name = "نفذت الكمية")]
        public bool OutOfStock { get; set; }
     

        [Display(Name = "الصورة1")]
        public string? ProductImage1 { get; set; }
        
        [Display(Name = "الصورة2")]
        public string? ProductImage2 { get; set; }
       
        [Display(Name = "الصورة3")]
        public string? ProductImage3 { get; set; }
      
        [Display(Name = "الصورة4")]
        public string? ProductImage4 { get; set; }
        
        [Display(Name = "الصورة5")]
        public string? ProductImage5 { get; set; }
        
        [Display(Name = "الصورة6")]
        public string? ProductImage6 { get; set; }
        
        public Product? product { get; set; }
        
    }
}

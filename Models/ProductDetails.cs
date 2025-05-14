using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class ProductDetails:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDetailsId { get; set; }
        [NotMapped]
        public override int Id => ProductDetailsId;
        [Required]
        [Display(Name = "المنتج")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string? ProductDiscreption { get; set; }
     
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

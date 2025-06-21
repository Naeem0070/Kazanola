using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class PerfumeDetailsVM:BaseEntity
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
        [Display(Name = "الصورة1")]
        public IFormFile? FileImage1 { get; set; }

        [Display(Name = "الصورة2")]
        public IFormFile? FileImage2 { get; set; }

        [Display(Name = "الصورة3")]
        public IFormFile? FileImage3 { get; set; }

        [Display(Name = "الصورة4")]
        public IFormFile? FileImage4 { get; set; }

        [Display(Name = "الصورة5")]
        public IFormFile? FileImage5 { get; set; }

        [Display(Name = "الصورة6")]
        public IFormFile? FileImage6 { get; set; }

        public Product? product { get; set; }
 
        public List<Product>? ProductsList { get; set; }
    
        public List<PerfumeDetails>? PerfumeDetailsList { get; set; }
    }
}

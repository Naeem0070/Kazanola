using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class PerfumeSize: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerfumeSizeId { get; set; }
        [NotMapped]
        public override int Id => PerfumeSizeId;
        [Required]
        [Display(Name = "الحجم")]
        public string? Size { get; set; }
        [Required]
        [Display(Name = "تكلفة الباكج مع الكحول")]
        public decimal? Cost { get; set; }
       
    }
   
}

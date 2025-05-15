using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kazanola.Models;

namespace Kazanola.ViewModels
{
    public class PerfumeSizeVM:BaseEntity
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
        public List<PerfumeSize>? SizeList { get; set; }
    }
}

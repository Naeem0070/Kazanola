using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class MenuModel: BaseEntity, IbaseEntity
    {
        [Key]
        public int MenuModelId { get; set; }
        [NotMapped]
        public int Id => MenuModelId;
        [Required]
        [Display(Name = "اسم التبويب")]
        public string? MenuName { get; set; }
        [Required]
        [Display(Name = "المسار")]
        public string? MenuUrl { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class MenuOfMenuModel: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuOfMenuModelId { get; set; }
        [NotMapped]
        public override int Id => MenuOfMenuModelId;
        [Required]
        [Display(Name = "اسم التبويب")]
        public string? MenuName { get; set; }
        [Required]
        [Display(Name = "المسار")]
        public string? MenuUrl { get; set; }
        [Display(Name = "ترتيب التبويب")]
        public int ParentMenuId { get; set; }
        public virtual MenuModel? ParentMenu { get; set; }
    }
}

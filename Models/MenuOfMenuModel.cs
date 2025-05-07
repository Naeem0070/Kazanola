using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class MenuOfMenuModel:BaseEntity
    {
        public int MenuOfMenuModelId { get; set; }
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

using Kazanola.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class MenuOfMenuVM:BaseEntity
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
        public List<MenuModel>? ListOfMinu { get; set; }
        public List<MenuOfMenuModel>? ListOfMenuOfMenu { get; set; }
    }
}

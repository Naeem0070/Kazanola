using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kazanola.Models;

namespace Kazanola.ViewModels
{
    public class MenuViewModel:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuModelId { get; set; }
        [NotMapped]
        public override int Id => MenuModelId;
        [Required]
        [Display(Name = "اسم التبويب")]
        public string? MenuName { get; set; }
        [Required]
        [Display(Name = "المسار")]
        public string? MenuUrl { get; set; }
        public List<MenuModel>? ListMenu { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class MenuModel:BaseEntity
    {
        public int MenuModelId { get; set; }
        public override int Id => MenuModelId;
        [Required]
        [Display(Name = "اسم التبويب")]
        public string? MenuName { get; set; }
        [Required]
        [Display(Name = "المسار")]
        public string? MenuUrl { get; set; }

    }
}

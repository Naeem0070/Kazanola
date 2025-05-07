using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class Notes:BaseEntity,IbaseEntity
    {
        [Key]
        public int NotesId { get; set; }
        [NotMapped]
        public int Id => NotesId;
        [Required]
        [Display(Name = "اسم النوتة")]
        public string? NotesName { get; set; }
        [Required]
        [Display(Name = "الصورة")]
        public string? NoteImage { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class Notes:BaseEntity
    {
        public int NotesId { get; set; }
        public override int Id => NotesId;
        [Required]
        [Display(Name = "اسم النوتة")]
        public string? NotesName { get; set; }
        [Required]
        [Display(Name = "الصورة")]
        public string? NoteImage { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class Notes: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotesId { get; set; }
        [NotMapped]
        public override int Id => NotesId;
        [Required]
        [Display(Name = "اسم النوتة")]
        public string? NotesName { get; set; }
        [Required]
        [Display(Name = "الصورة")]
        public string? NoteImage { get; set; }

    }
}

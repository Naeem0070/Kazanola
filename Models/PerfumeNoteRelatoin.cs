using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class PerfumeNoteRelatoin: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerfumeNoteRelatoinId { get; set; }
        [NotMapped]
        public override int Id => PerfumeNoteRelatoinId;
        public int PerfumeDetailsId { get; set; }
        public int NotesId { get; set; }
        public int NotePositoinId { get; set; }
        public  NotePositoin? NotePositoin { get; set; }
        public PerfumeDetails? PerfumeDetails { get; set; }
        public Notes? Notes { get; set; }
    }
}

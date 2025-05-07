namespace Kazanola.Models
{
    public class PerfumeNoteRelatoin:BaseEntity
    {
        public int PerfumeNoteRelatoinId { get; set; }
        public override int Id => PerfumeNoteRelatoinId;
        public int PerfumeDetailsId { get; set; }
        public int NotesId { get; set; }
        public string[]? NotePositoin { get; set; } = ["قاعدة", "القلب", "الافتتاحية"];
        public PerfumeDetails? PerfumeDetails { get; set; }
        public Notes? Notes { get; set; }
    }
}

using Kazanola.Models;

namespace Kazanola.ViewModels
{
    public class PerfumeVM
    {
        public int PerfumeId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public List<NoteVM> Notes { get; set; } = new();
    }
}

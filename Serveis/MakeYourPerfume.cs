using Kazanola.Models;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kazanola.Serveis
{

    [Route("api/[controller]")]
    [ApiController]
    public class MakeYourPerfume : ControllerBase
    {
        private readonly AppDbContext _context;

        public MakeYourPerfume(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<MakeYourPerfume>        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MakeYourPerfume>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MakeYourPerfume>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MakeYourPerfume>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MakeYourPerfume>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("GetPerfumesByNotes")]
        public async Task<ActionResult<PerfumeSearchResult>> GetPerfumesByNotes([FromBody] List<int> selectedNoteIds)
        {
            // Get all perfumes that contain ALL the selected notes
            var perfumes = await _context.PerfumeNoteRelatoins
                .Include(pnr => pnr.PerfumeDetails)
                    .ThenInclude(pd => pd.product)
                .Include(pnr => pnr.Notes)
                .Where(pnr => selectedNoteIds.Contains(pnr.NotesId))
                .GroupBy(pnr => pnr.PerfumeDetailsId)
                .Where(g => selectedNoteIds.All(noteId => g.Any(pnr => pnr.NotesId == noteId)))
                .Select(g => g.First().PerfumeDetails)
                .ToListAsync();

            // Get all notes from these perfumes
            var allNotes = await _context.PerfumeNoteRelatoins
                .Include(pnr => pnr.Notes)
                .Where(pnr => perfumes.Select(p => p.PerfumeDetailsId).Contains(pnr.PerfumeDetailsId))
                .Select(pnr => pnr.Notes)
                .Distinct()
                .ToListAsync();

            var result = new PerfumeSearchResult
            {
                Perfumes = perfumes.Select(p => new PerfumeVM
                {
                    PerfumeId = p.PerfumeDetailsId,
                    ProductName = p.product.ProductName,
                    ProductImage = p.ProductImage1,
                    Notes = _context.PerfumeNoteRelatoins
                        .Include(pnr => pnr.Notes)
                        .Where(pnr => pnr.PerfumeDetailsId == p.PerfumeDetailsId)
                        .Select(pnr => new NoteVM
                        {
                            NoteId = pnr.Notes.NotesId,
                            NoteName = pnr.Notes.NotesName,
                            NoteImage = pnr.Notes.NoteImage
                        }).ToList()
                }).ToList(),
                AllNotes = allNotes.Select(n => new NoteVM
                {
                    NoteId = n.NotesId,
                    NoteName = n.NotesName,
                    NoteImage = n.NoteImage
                }).ToList()
            };

            return Ok(result);
        }
    }

    public class PerfumeSearchResult
    {
        public List<PerfumeVM> Perfumes { get; set; } = new();
        public List<NoteVM> AllNotes { get; set; } = new();
    }
}

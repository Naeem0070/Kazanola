using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class NotePositoin: BaseEntity, IbaseEntity
    {
        [Key]
        public int NotePositoinId { get; set; }
        [NotMapped]
        public int Id => NotePositoinId;
        public string? Name { get; set; }
     
      
    }
}

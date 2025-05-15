using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class NotePositoin: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotePositoinId { get; set; }
        [NotMapped]
        public override int Id => NotePositoinId;
        public string? Name { get; set; }
     
      
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
        public class BaseEntity
        {

        [NotMapped]
        public virtual int Id { get; }
        public bool IsActive { get; set; }
            public bool IsDelete { get; set; }

            public string? CreateId { get; set; }
            public DateTime? CreateDate { get; set; }

            public string? EditId { get; set; }
            public DateTime? EditDate { get; set; }

        }
    

}

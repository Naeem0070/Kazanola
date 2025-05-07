using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models
{
    public class NewsLetterTarncaction: BaseEntity, IbaseEntity
    {
        [Key]
        public int NewsLetterTarncactionId { get; set; }
        [NotMapped]
        public int Id => NewsLetterTarncactionId;
        [Required]
        [Display(Name = "البريد الالكتروني")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "تاريخ الاشتراك")]
        public DateTime SubscriptionDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "حالة الاشتراك")]
        public bool IsSubscribed { get; set; } = true;
    }
}

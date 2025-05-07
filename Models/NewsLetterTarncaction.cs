using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models
{
    public class NewsLetterTarncaction:BaseEntity
    {
        public int NewsLetterTarncactionId { get; set; }
        public override int Id => NewsLetterTarncactionId;
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

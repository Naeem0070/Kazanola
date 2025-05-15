using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kazanola.Models;

namespace Kazanola.ViewModels
{
    public class NewsLetterTrancatoinVm:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsLetterTarncactionId { get; set; }
        [NotMapped]
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
        public List<NewsLetterTarncaction>? listofNewsLatter { get; set; }
    }
}

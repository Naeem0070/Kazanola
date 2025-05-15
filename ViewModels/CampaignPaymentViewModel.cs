using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class CampaignPaymentViewModel:BaseEntity
    {
        public int CampaignPaymentID { get; set; }
        [Required]
        [Display(Name = "اسم الحملة")]
        public string? CampaignName { get; set; }
        [Required]
        [Display(Name = "اسم الصفحة")]
        public int? PageID { get; set; }
        [Required]
        [Display(Name = "قيمة الدفعة")]
        public decimal? Payment { get; set; }
        [Required]
        [Display(Name = "تاريخ الدفع")]
        public DateOnly? PaymentDate { get; set; }

        public virtual Page? Page { get; set; }
        public List<CampaignPayment>? CampaignPaymentList { get; set; }
        public List<Page>? PageList { get; set; }
    }
}

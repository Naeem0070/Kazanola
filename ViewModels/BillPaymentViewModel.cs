using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class BillPaymentViewModel:BaseEntity
    {
        public int BillPaymentID { get; set; }
        [Required]
        [Display(Name = "رقم الفاتورة")]
        public int? BillID { get; set; }
        [Required]
        [Display(Name = "قيمة الدفعة")]
        public decimal PaymentAmount { get; set; }

        [Display(Name = "طريقة الدفع")]
        public string? PaymentMethod { get; set; }
        [Required]
        [Display(Name = "تاريخ الدفع")]
        public DateTime? BillPaymentDate { get; set; }

        public virtual ScheduleBill? Bill { get; set; }
        public List<BillPayment>? BillPaymentsList { get; set; }
        public List<ScheduleBill>? ScheduleBillsList { get; set; }
    }
}

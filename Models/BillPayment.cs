using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models;

public partial class BillPayment : BaseEntity
{
    

    public int BillPaymentID { get; set; }
    [Required]
    [Display(Name ="رقم الفاتورة")]
    public int? BillID { get; set; }
    [Required]
    [Display(Name ="قيمة الدفعة")]
    public decimal PaymentAmount { get; set; }

    [Display(Name ="طريقة الدفع")]
    public string? PaymentMethod { get; set; }
    [Required]
    [Display(Name ="تاريخ الدفع")]
    public DateTime? BillPaymentDate { get; set; }

    public virtual ScheduleBill? Bill { get; set; }
}

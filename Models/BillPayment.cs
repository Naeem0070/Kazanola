using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class BillPayment : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BillPaymentID { get; set; }
    [NotMapped]
    public override int Id => BillPaymentID;
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class CampaignPayment: BaseEntity, IbaseEntity
{
    
    public int CampaignPaymentID { get; set; }
    [NotMapped]
    public int Id => CampaignPaymentID;
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
}

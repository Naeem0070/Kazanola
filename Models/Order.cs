using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class Order: BaseEntity
{
   
    public int OrderID { get; set; }
   
    [Required]
    [Display(Name = "السعر الكلي")]
    public decimal? OrderTotalPrice { get; set; }
    [Required]
    [Display(Name = "اسم العميل")]
    public string? CustomerName { get; set; }
    [Required]
    [Display(Name = "شركة التوصيل")]
    public string? DeliveryCompany { get; set; }
    [Required]
    [Display(Name = "التاريخ")]
    public DateOnly? OrderDate { get; set; }
   
    [Display(Name = "تم التوصيل؟")]
    public bool IsDelivered { get; set; }
    [Display(Name = "تم الدفع؟")]
    public bool IsPaid { get; set; }
    [Required]
    [Display(Name = "اسم الصفحة")]
    public int? PageID { get; set; }
    [Required]
    [Display(Name = "المدينة")]
    public string? LocationCity { get; set; }
    [Required]
    [Display(Name = "الحي")]
    public string? Neighborhood { get; set; }
    [Required]
    [Display(Name = "الشارع")]
    public string? Street { get; set; }
    public virtual Page? Page { get; set; }
}

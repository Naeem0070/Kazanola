using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models;

public partial class Product: BaseEntity
{
    public int ProductID { get; set; }
    [Required]
    [Display(Name = "اسم المنتج")]
    public string? ProductName { get; set; }
    [Required]
    [Display(Name = "التكلفة")]
    public decimal? ProductCost { get; set; }
    [Required]
    [Display(Name = "سعر البيع")]
    public decimal? ProductPrice { get; set; }

    [Display(Name = "صافي الربح")]
    public decimal? Benefit { get; set; }
    [Required]
    [Display(Name = "رقم الفتورة")]
    public int? BillID { get; set; }
    [Required]
    [Display(Name = "البراند")]
    public int? BrandId { get; set; }
 
    [Display(Name = "الصورة")]
    public string? ProductImageUrl { get; set; }

    public virtual ScheduleBill? Bill { get; set; }

    public virtual Brand? Brands { get; set; }

   
}

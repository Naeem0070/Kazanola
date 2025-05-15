using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class Product: BaseEntity    
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }
    [NotMapped]
    public override int Id => ProductID;
    [Required]
    [Display(Name = "اسم المنتج")]
    public string? ProductName { get; set; }
    [Required]
    [Display(Name = "التكلفة")]
    public decimal? ProductCost { get; set; }
    [Required]
    [Display(Name = "التكلفة بعد التنزيل")]
    public decimal? ProductCostAfterBay { get; set; }
    [Required]
    [Display(Name = "سعر البيع")]
    public decimal? ProductPrice { get; set; }

    [Display(Name = "صافي الربح")]
    public decimal? Benefit { get; set; }
 
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

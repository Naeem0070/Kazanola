using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class OrderDetail: BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderDetailID { get; set; }
    [NotMapped]
    public override int Id => OrderDetailID;
    [Required]
    [Display(Name = "رقم الطلب")]
    public int? OrderID { get; set; }
    [Required]
    [Display(Name = "اسم المنج")]
    public int? ProductID { get; set; }
    [Required]
    [Display(Name = "الكمية")]
    public int? Quantity { get; set; }
    [Required]
    [Display(Name = "سعر البيع")]
    public decimal? ProductSalePrice { get; set; }
  
    [Display(Name = "السعر الكلي")]
    public decimal? TotalPrice { get; set; }
    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}

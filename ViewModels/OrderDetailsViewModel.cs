using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class OrderDetailsViewModel:BaseEntity
    {
        public int OrderDetailID { get; set; }
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
        public List<OrderDetail>? OrderDetailsList { get; set; }
        public List<Order>? OrderList { get; set; }
        public List<Product>? ProductList { get; set; }
    }
}

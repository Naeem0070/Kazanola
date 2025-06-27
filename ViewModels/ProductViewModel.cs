using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class ProductViewModel:BaseEntity
    {
        public int ProductID { get; set; }
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
        [Display(Name = "عدد المشاهدات")]
        public int ClickCount { get; set; } = 0;

        public virtual ScheduleBill? Bill { get; set; }

        public virtual Brand? Brands { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile? ProductImageFile { get; set; }
        public List<Product>? ProductList { get; set; }
        public List<ScheduleBill>? ScheduleBillList { get; set; }
        public List<Brand>? BrandList { get; set; }
    }
}

using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class ScheduleBillViewModel:BaseEntity
    {
       
        [Required]
        [Display(Name = "رقم")]
        public int ScheduleBillID { get; set; }
        [Required]
        [Display(Name = "رقم الفاتورة")]
        public String? BillNumber { get; set; }
        [Required]
        [Display(Name = "اسم الشركة")]
        public string? BillCompany { get; set; }
        [Required]
        [Display(Name = "قيمة الفاتورة")]
        public decimal? BillCost { get; set; }
        [Required]
        [Display(Name = "تاريخ الاستلام")]
        public DateOnly? BillDate { get; set; }

        public virtual List<ScheduleBill>? ScheduleBillList { get; set; } 
    }
}

using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class EmployeeWithdrawalViewModel:BaseEntity
    {
        public int EmployeeWithdrawalID { get; set; }
        [Required]
        [Display(Name = "اسم الموظف")]
        public int? EmployeeID { get; set; }
        [Required]
        [Display(Name = "قيمة السحب")]
        public decimal? WithdrawalAmount { get; set; }
        [Display(Name = "تفاصيل")]
        public string? Details { get; set; }
        [Required]
        [Display(Name = "التاريخ")]
        public DateOnly? WithdrawalDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public List<EmployeeWithdrawal>? EmployeeWithdrawalList { get; set; }
        public List<Employee>? EmployeeList { get; set; }
    }
}

using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class EmployeeViewModel:BaseEntity
    {
        public int EmployeeID { get; set; }
        [Required]
        [Display(Name = "اسم الموظف")]
        public string? EmployeeName { get; set; }
        [Required]
        [Display(Name = "الراتب")]
        public decimal? Salary { get; set; }
        [Required]
        [Display(Name = "قيمة الساعة")]
        public decimal? HourlyRate { get; set; }
        public List<Employee>? EmployeesList { get; set; }
    }
}

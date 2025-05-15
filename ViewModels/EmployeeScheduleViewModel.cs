using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class EmployeeScheduleViewModel:BaseEntity
    {
        public int EmployeeScheduleID { get; set; }
        [Required]
        [Display(Name = "اسم الموظف")]
        public int? EmployeeID { get; set; }
        [Required]
        [Display(Name = "بدأ الدوام")]
        public DateTime? StartTime { get; set; }
        [Required]
        [Display(Name = "نهاية الدوام")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "عددالساعات")]
        public decimal? Hours { get; set; }

        public virtual Employee? Employee { get; set; }
        public List<Employee>? EmployeesList { get; set; }
        public List<EmployeeSchedule>? EmployeeSchedulesList { get; set; }
    }
}

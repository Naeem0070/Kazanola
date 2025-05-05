using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models;

public partial class Employee: BaseEntity
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

    }

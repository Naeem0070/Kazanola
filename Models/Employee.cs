using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class Employee: BaseEntity, IbaseEntity
{
    
    public int EmployeeID { get; set; }
    [NotMapped]
    public int Id => EmployeeID;
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

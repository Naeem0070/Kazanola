using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class EmployeeWithdrawal: BaseEntity, IbaseEntity
{
    
    public int EmployeeWithdrawalID { get; set; }
    [NotMapped]
    public int Id => EmployeeWithdrawalID;
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
}

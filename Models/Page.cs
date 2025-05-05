using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models;

public partial class Page: BaseEntity
{
    public int PageID { get; set; }
    [Required]
    [Display(Name = "اسم الصفحة")]
    public string? PageName { get; set; }
    [Display(Name = "الرابط")]
    public string? URLLink { get; set; }
    }

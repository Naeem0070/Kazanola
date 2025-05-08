using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class Page: BaseEntity,IbaseEntity
{
  
    public int PageID { get; set; }
    [NotMapped]
    public int Id => PageID;
    [Required]
    [Display(Name = "اسم الصفحة")]
    public string? PageName { get; set; }
    [Display(Name = "الرابط")]
    public string? URLLink { get; set; }
    }

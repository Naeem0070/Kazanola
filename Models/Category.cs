using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.Models;

public partial class Category: BaseEntity
{
    public int CategoryID { get; set; }
    [Required]
    [Display(Name = "الصنف")]
    public string? CategoryName { get; set; }
    [Display(Name = "الصورة")]
    public int? ImageUrl { get; set; }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class Category: BaseEntity, IbaseEntity
{
    
    public int CategoryID { get; set; }
    [NotMapped]
    public int Id => CategoryID;
    [Required]
    [Display(Name = "الصنف")]
    public string? CategoryName { get; set; }
    [Display(Name = "الصورة")]
    public int? ImageUrl { get; set; }

}

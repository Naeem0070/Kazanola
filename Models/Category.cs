using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public  class Category: BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID { get; set; }
    [NotMapped]
    public override int Id => CategoryID;
    [Required]
    [Display(Name = "الصنف")]
    public string? CategoryName { get; set; }
    [Display(Name = "الصورة")]
    public String? ImageUrl { get; set; }

}

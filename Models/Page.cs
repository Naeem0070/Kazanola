using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kazanola.Models;

public partial class Page: BaseEntity   
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PageID { get; set; }
    [NotMapped]
    public override int Id => PageID;
    [Required]
    [Display(Name = "اسم الصفحة")]
    public string? PageName { get; set; }
    [Display(Name = "الرابط")]
    public string? URLLink { get; set; }
    }

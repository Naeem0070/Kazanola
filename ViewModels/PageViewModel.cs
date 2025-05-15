using Kazanola.Models;
using System.ComponentModel.DataAnnotations;

namespace Kazanola.ViewModels
{
    public class PageViewModel:BaseEntity
    {
        public int PageID { get; set; }
        [Required]
        [Display(Name = "اسم الصفحة")]
        public string? PageName { get; set; }
        [Display(Name = "الرابط")]
        public string? URLLink { get; set; }
        public List<Page>? PageList { get; set; }
    }
}

using Kazanola.Models;
using Kazanola.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kazanola.Areas.Admin.Controllers
{
    public class AdsPanelsModelController : Controller
        
    {
        public IRepository<AdsPanelsModel> repo { get; set; }
        public AdsPanelsModelController(IRepository<AdsPanelsModel> repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

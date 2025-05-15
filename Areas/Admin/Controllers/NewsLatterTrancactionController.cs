using Kazanola.Models;
using Kazanola.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kazanola.Areas.Admin.Controllers
{
    public class NewsLatterTrancactionController : Controller
    {
        public IRepository<NewsLetterTarncaction> NewsLatter { get; set; }
        public NewsLatterTrancactionController(IRepository<NewsLetterTarncaction> NewsLatter)
        {
            this.NewsLatter = NewsLatter;
        }
        public IActionResult Index()
        {
            return View(NewsLatter.View());
        }
        public ActionResult Details(int id)
        {
            var data = NewsLatter.Find(id);
            return View(data);
        }

    }
}

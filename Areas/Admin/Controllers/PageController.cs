using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kazanola.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PageController : Controller
    {
        public IRepository<Page> page { get; set; }
        public PageController(IRepository<Page> page)
        {
            this.page = page;
        }
        public IActionResult Index(int EditId)
        {
            Page EditData = new();
            if (EditId!=0)
            {
                EditData = page.Find(EditId);
            }
            var ViewObj = new PageViewModel
            {
                PageID = EditData.PageID,
                PageName = EditData.PageName,
                URLLink = EditData.URLLink,
                PageList = page.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, PageViewModel collection) 
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    Page EditData = new();
                    if (EditId != 0)
                    {
                        EditData = page.Find(EditId);
                    }
                    var ViewObj = new PageViewModel
                    {
                        PageID = EditData.PageID,
                        PageName = EditData.PageName,
                        URLLink = EditData.URLLink,
                        PageList = page.View()
                    };
                    return View(ViewObj);
                }
                var data = new Page
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId= userId,
                    PageID = collection.PageID,
                    PageName = collection.PageName,
                    URLLink = collection.URLLink,
                };
                if(collection.PageID==0)
                {
                    page.Add(data);
                }
                else
                {
                    page.Update(collection.PageID,data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, Page collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = page.Find(id);
            collection.EditId = userId;
            page.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            page.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

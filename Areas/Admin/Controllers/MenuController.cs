using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kazanola.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        public IRepository<MenuModel> menu { get; set; }
        public MenuController(IRepository<MenuModel> menu)
        {
            this.menu = menu;
        }
        public IActionResult Index(int EditId)
        {
            MenuModel EditData = new();
            if(EditId!=0)
            {
                EditData=menu.Find(EditId);
            }
            var ViewObj = new MenuViewModel
            {
                MenuModelId = EditData.MenuModelId,
                MenuName = EditData.MenuName,
                MenuUrl = EditData.MenuUrl,
                ListMenu=menu.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult index(MenuModel model, int EditId)
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("", "املاء كل الحقول ");
                    MenuModel EditData = new();
                    if (EditId != 0)
                    {
                        EditData = menu.Find(EditId);
                    }
                    var ViewObj = new MenuViewModel
                    {
                        MenuModelId = EditData.MenuModelId,
                        MenuName = EditData.MenuName,
                        MenuUrl = EditData.MenuUrl,
                        ListMenu = menu.View(),
                    };
                    return View(ViewObj);
                }
                var NewData = new MenuModel
                {
                    MenuModelId = model.MenuModelId,
                    MenuName = model.MenuName,
                    MenuUrl = model.MenuUrl,
                };
                if (model.MenuModelId == 0)
                {
                    menu.Add(NewData);
                }
                else
                {
                    menu.Update(model.MenuModelId, NewData);
                }
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, MenuModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = menu.Find(id);
            collection.EditId = userId;
            menu.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            menu.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

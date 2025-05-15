using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kazanola.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuOfMenuController : Controller
    {
        public IRepository<MenuOfMenuModel> MenuOfMenu { get; set; }
        public IRepository<MenuModel> Menu { get; set; }
        public MenuOfMenuController(IRepository<MenuOfMenuModel> MenuOfMenu, IRepository<MenuModel> Menu)
        {
         this.MenuOfMenu = MenuOfMenu;
            this.Menu = Menu;
        }
        public IActionResult Index(int EditId)
        {
            MenuOfMenuModel EditData = new MenuOfMenuModel();
            if (EditId > 0) { EditData = MenuOfMenu.Find(EditId); }
            var ViewObj = new MenuOfMenuVM 
            {
                MenuOfMenuModelId = EditData.MenuOfMenuModelId,
                MenuName =EditData.MenuName,
                MenuUrl=EditData.MenuUrl,
                ParentMenu=EditData.ParentMenu,
                ListOfMenuOfMenu=MenuOfMenu.View(),
                ListOfMinu=Menu.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int EditId,MenuOfMenuVM collection) 
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("","أملا كل الحقول");
                    MenuOfMenuModel EditData = new MenuOfMenuModel();
                    if (EditId > 0) { EditData = MenuOfMenu.Find(EditId); }
                    var ViewObj = new MenuOfMenuVM
                    {
                        MenuOfMenuModelId=EditData.MenuOfMenuModelId,
                        MenuName = EditData.MenuName,
                        MenuUrl = EditData.MenuUrl,
                        ParentMenu = EditData.ParentMenu,
                        ListOfMenuOfMenu = MenuOfMenu.View(),
                        ListOfMinu = Menu.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new MenuOfMenuModel 
                {
                    MenuOfMenuModelId=collection.MenuOfMenuModelId,
                    MenuName = collection.MenuName,
                    MenuUrl = collection.MenuUrl,
                    ParentMenuId = collection.ParentMenuId,
                };
                if (collection.MenuOfMenuModelId==0)
                    MenuOfMenu.Add(NewData);
                else
                    MenuOfMenu.Update(collection.MenuOfMenuModelId,NewData);
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, MenuOfMenuModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = MenuOfMenu.Find(id);
            collection.EditId = userId;
            MenuOfMenu.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            MenuOfMenu.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

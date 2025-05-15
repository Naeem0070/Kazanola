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
    public class CategoryController : Controller
    {
        public IRepository<Category> category { get; set; }
        public CategoryController(IRepository<Category> category)
        {
            this.category = category;
        }
        public IActionResult Index(int EditId)
        {
            Category EditData= new Category();
            if (EditId != 0) 
            {
                EditData = category.Find(EditId);
            }
            var ViewObj = new CategoryViewModel
            {
                CategoryID = EditData.CategoryID,
                CategoryName = EditData.CategoryName,
                CategoryList = category.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, CategoryViewModel collection)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    Category EditData = new Category();
                    if (EditId != 0)
                    {
                        EditData = category.Find(EditId);
                    }
                    var ViewObj = new CategoryViewModel
                    {
                        CategoryID = EditData.CategoryID,
                        CategoryName = EditData.CategoryName,
                        CategoryList = category.View(),
                    };
                    return View(ViewObj);
                }
                var data = new Category
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    CategoryID = collection.CategoryID,
                    CategoryName = collection.CategoryName,
                };
                if (collection.CategoryID == 0)
                {
                    category.Add(data);
                }
                else
                {
                    category.Update(collection.CategoryID, data);
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
        public ActionResult Delete(int id, Category collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = category.Find(id);
            collection.EditId = userId;
            category.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            category.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

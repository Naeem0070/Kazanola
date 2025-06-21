using Kazanola.Areas.Admin.MyClass;
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
    public class BrandController : Controller
    {
        public IRepository<Brand> brand { get; set; }
        public IRepository<Category> category { get; set; }
        public IClassHelper helper { get; set; }
        public BrandController(IRepository<Brand> brand, IRepository<Category> category, IClassHelper helper)
        {
            this.brand = brand;
            this.category = category;
            this.helper = helper;
        }
        public IActionResult Index(int EditId)
        {
            Brand EditData = new();
            if (EditId != 0) 
            {
                EditData = brand.Find(EditId);
            }
            var ViewObj = new BrandViewModel
            {
                BrandId = EditData.BrandId,
                CategoryId = EditData.CategoryId,
                BrandName=EditData.BrandName,
                ImageUrl= EditData.ImageUrl,
                BrandList = brand.View(),
                CategoryList = category.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, BrandViewModel collection)
        {


            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string file = helper.SaveImage(collection.ImageFile, "Brand");
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    Brand EditData = new();
                    if (EditId != 0)
                    {
                        EditData = brand.Find(EditId);
                    }
                    var ViewObj = new BrandViewModel
                    {
                        BrandId = EditData.BrandId,
                        CategoryId = EditData.CategoryId,
                        BrandName = EditData.BrandName,
                        ImageUrl = EditData.ImageUrl,
                        BrandList = brand.View(),
                        CategoryList = category.View(),
                    };
                    return View(ViewObj);
                }
                var NewData = new Brand
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    BrandId = collection.BrandId,
                    BrandName = collection.BrandName,
                    ImageUrl = string.IsNullOrEmpty(file) ? collection.ImageUrl : file,
                    CategoryId = collection.CategoryId

                };
                if (collection.BrandId == 0)
                {
                    brand.Add(NewData);
                }
                else
                {
                    brand.Update(collection.BrandId, NewData);
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
        public ActionResult Delete(int id, Brand collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = brand.Find(id);
            collection.EditId = userId;
            brand.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            brand.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

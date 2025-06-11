using Kazanola.Areas.Admin.MyClass;
using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace Kazanola.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SaleBanerController : Controller
    {
        public ISaleBanerReposetory<SaleBaner> sale { get; set; }
        public IClassHelper helber { get; set; }
        public SaleBanerController(ISaleBanerReposetory<SaleBaner> sale, IClassHelper helber)
        {
            this.sale = sale;
            this.helber= helber;
        }
        public IActionResult Index(int EditId)
        {
            SaleBaner EditData = new SaleBaner();
            if (EditId > 0) 
            {
                EditData = sale.Find(EditId);
            }
            var ViewObject = new SaleBanerVM
            {
                SaleBanerId = EditData.SaleBanerId,
                Title = EditData.Title,
                Description = EditData.Description,
                ImageUrl = EditData.ImageUrl,
                IsFeatured = EditData.IsFeatured,
                FeaturedUntil = EditData.FeaturedUntil,
                PromotionalText = EditData.PromotionalText,
                Price = EditData.Price,

                SaleBanerList = sale.View()
            };
            return View(ViewObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(int EditId ,SaleBanerVM model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string Image = helber.SaveImage(model.ImageFile, "SaleBaner_image");
                SaleBaner saleBaner = new SaleBaner
                {
                    SaleBanerId = model.SaleBanerId,
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = Image == "" ? model.ImageUrl : Image,
                    IsFeatured = model.IsFeatured,
                    FeaturedUntil = model.FeaturedUntil,
                    PromotionalText = model.PromotionalText,
                    Price = model.Price,
                    CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                    EditId = userId,
                };
                if (saleBaner.SaleBanerId > 0)
                {
                    sale.Update(model.SaleBanerId,saleBaner);
                }
                else
                {
                    sale.Add(saleBaner);
                }
                return RedirectToAction("Index");
            }
            else 
            {
                ModelState.AddModelError("","املاء كل الحقول");
                SaleBaner EditData = new SaleBaner();
                if (EditId > 0)
                {
                    EditData = sale.Find(EditId);
                }
                var ViewObject = new SaleBanerVM
                {
                    SaleBanerId = EditData.SaleBanerId,
                    Title = EditData.Title,
                    Description = EditData.Description,
                    ImageUrl = EditData.ImageUrl,
                    IsFeatured = EditData.IsFeatured,
                    FeaturedUntil = EditData.FeaturedUntil,
                    PromotionalText = EditData.PromotionalText,
                    Price = EditData.Price,

                    SaleBanerList = sale.View()
                };
                return View(ViewObject);
            }
            
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, SaleBaner collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = sale.Find(id);
            collection.EditId = userId;
            sale.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            sale.Active(id);

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Update_Featured(int id)
        {

            sale.Featured(id);

            return RedirectToAction(nameof(Index));
        }
    }

}

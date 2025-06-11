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
    public class ChooseUsController : Controller
    {
        public IRepository<WhyChooseUsModel> ChooseUsList { get; set; }
        public IClassHelper helper { get; set; }
        public ChooseUsController(IRepository<WhyChooseUsModel> ChooseUsList, IClassHelper helper)
        {
            this.helper = helper;
            this.ChooseUsList= ChooseUsList;
        }
        public IActionResult Index(int EditId)
        {
            WhyChooseUsModel EditData = new WhyChooseUsModel();
            if (EditId > 0) { EditData = ChooseUsList.Find(EditId); }
            var ViewObj = new WhyChooseUsVM
            {
                WhyChooseUsId = EditData.WhyChooseUsId,
                Title = EditData.Title,
                Description = EditData.Description,
                ButtonUrl = EditData.ButtonUrl,
                ImageUrl1 = EditData.ImageUrl1,
                ImageUrl2 = EditData.ImageUrl2,
                ChooseUsList = ChooseUsList.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, WhyChooseUsVM model)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string Image = helper.SaveImage(model.ImageFile1, "ChooseUs_image");
                string Image2 = helper.SaveImage(model.ImageFile2, "ChooseUs_image");
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "املا كل الحقول");
                    WhyChooseUsModel EditData = new WhyChooseUsModel();
                    if (EditId > 0) { EditData = ChooseUsList.Find(EditId); }
                    var ViewObj = new WhyChooseUsVM
                    {
                        WhyChooseUsId = EditData.WhyChooseUsId,
                        Title = EditData.Title,
                        Description = EditData.Description,
                        ButtonUrl = EditData.ButtonUrl,
                        ImageUrl1 = EditData.ImageUrl1,
                        ImageUrl2 = EditData.ImageUrl2,
                        ChooseUsList = ChooseUsList.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new WhyChooseUsModel
                {
                   WhyChooseUsId=model.WhyChooseUsId,
                   Title=model.Title,
                   Description=model.Description,
                   ButtonUrl=model.ButtonUrl,
                   ImageUrl1 = Image == "" ? model.ImageUrl1 : Image,
                   ImageUrl2 = Image2 == "" ? model.ImageUrl1 : Image2,
                   CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                   EditId = userId,
                };
                if (model.WhyChooseUsId == 0) { ChooseUsList.Add(NewData); }
                else { ChooseUsList.Update(model.WhyChooseUsId, NewData); }
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, WhyChooseUsModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = ChooseUsList.Find(id);
            collection.EditId = userId;
            ChooseUsList.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            ChooseUsList.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

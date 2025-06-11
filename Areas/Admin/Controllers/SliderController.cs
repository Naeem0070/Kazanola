using Kazanola.Areas.Admin.MyClass;
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
    public class SliderController : Controller
    {
        public IRepository<SliderModel> slider { get; set; }
        public IClassHelper helper { get; set; }
        public SliderController(IRepository<SliderModel> slider, IClassHelper helper)
        {
            this.slider=slider;
            this.helper = helper;
        }
        public IActionResult Index(int EditId)
        {
            SliderModel EditData = new();
            if (EditId > 0) 
            {
                EditData = slider.Find(EditId);
            }
            var ViewObj = new SliderVM
            {
                SliderModelId = EditData.SliderModelId,
                ImageUrl = EditData.ImageUrl,
                Description = EditData.Description,
                Title = EditData.Title,
                ButtonsLink = EditData.ButtonsLink,
                ListOfSlider = slider.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, SliderVM model) 
        {
            try 
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string Image = helper.SaveImage(model.ImageFile, "Slider_image");
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("", "املا كل الحقول");
                    SliderModel EditData = new();
                    if (EditId > 0)
                    {
                        EditData = slider.Find(EditId);
                    }
                    var ViewObj = new SliderVM
                    {
                        SliderModelId = EditData.SliderModelId,
                        ImageUrl = EditData.ImageUrl,
                        Description = EditData.Description,
                        Title = EditData.Title,
                        ButtonsLink = EditData.ButtonsLink,
                        ListOfSlider = slider.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new SliderModel 
                {
                    SliderModelId=model.SliderModelId,
                    ImageUrl = Image == "" ? model.ImageUrl : Image,
                    Description = model.Description,
                    Title = model.Title,
                    ButtonsLink = model.ButtonsLink,
                    CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                    EditId = userId,
                };
                if (model.SliderModelId == 0) { slider.Add(NewData); }
                else { slider.Update(model.SliderModelId,NewData); }
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
        public ActionResult Delete(int id, SliderModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = slider.Find(id);
            collection.EditId = userId;
            slider.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            slider.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

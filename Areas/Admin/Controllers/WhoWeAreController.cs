using Kazanola.Areas.Admin.MyClass;
using Kazanola.Models.Repositories;
using Kazanola.Models;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Kazanola.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class WhoWeAreController : Controller
    {
        public IRepository<WhoWeAreModel> who { get; set; }
        public IClassHelper helper { get; set; }
        public WhoWeAreController(IRepository<WhoWeAreModel> who, IClassHelper helper)
        {
            this.who = who;
            this.helper = helper;
        }
        [HttpGet]
        public IActionResult Index(int EditId)
        {
            WhoWeAreModel EditData = new();
            if (EditId > 0) { EditData = who.Find(EditId); }
            var ViewObj = new WhoWeAreVM
            {
                WhoWeAreId = EditData.WhoWeAreId,
                Title = EditData.Title,
                Description = EditData.Description,
                ImageUrl = EditData.ImageUrl,
                ButtonUrl = EditData.ButtonUrl,
                ListofWe = who.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, WhoWeAreVM model)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string Image = helper.SaveImage(model.ImageFile, "WhoWeAre_Image");
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "املا كل الحقول");
                    WhoWeAreModel EditData = new();
                    if (EditId > 0) { EditData = who.Find(EditId); }
                    var ViewObj = new WhoWeAreVM
                    {
                        WhoWeAreId = EditData.WhoWeAreId,
                        Title = EditData.Title,
                        Description = EditData.Description,
                        ImageUrl = EditData.ImageUrl,
                        ButtonUrl = EditData.ButtonUrl,
                        ListofWe = who.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new WhoWeAreModel
                {
                    CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                    EditId = userId,
                    ImageUrl = Image == "" ? model.ImageUrl : Image,
                    WhoWeAreId = model.WhoWeAreId,
                    Title = model.Title,
                    Description = model.Description,
                    ButtonUrl = model.ButtonUrl,

                };
                if (model.WhoWeAreId == 0) { who.Add(NewData); }
                else { who.Update(model.WhoWeAreId, NewData); }
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, WhoWeAreModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = who.Find(id);
            collection.EditId = userId;
            who.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            who.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

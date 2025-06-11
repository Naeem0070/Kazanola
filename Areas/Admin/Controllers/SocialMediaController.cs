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
    public class SocialMediaController : Controller
    {
        public IRepository<SocialMediaModel> social { get; set; }
        public IClassHelper helper { get; set; }
        public SocialMediaController(IRepository<SocialMediaModel> social, IClassHelper helper)
        {
            this.social = social;
            this.helper = helper;
        }
        public IActionResult Index(int EditId)
        {
            SocialMediaModel EditData = new();
            if (EditId > 0) { EditData = social.Find(EditId); }
            var ViewObj = new SocialMediaVM 
            {
                SocialMediaId=EditData.SocialMediaId,
                PlatformName=EditData.PlatformName,
                Link=EditData.Link,
                ImageUrl=EditData.ImageUrl,
                ListOfSocial=social.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, SocialMediaVM model) 
        {
            try 
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string Image = helper.SaveImage(model.ImageFile, "Social_image");
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("", "املا كل الحقول");
                    SocialMediaModel EditData = new();
                    if (EditId > 0) { EditData = social.Find(EditId); }
                    var ViewObj = new SocialMediaVM
                    {
                        SocialMediaId = EditData.SocialMediaId,
                        PlatformName = EditData.PlatformName,
                        Link = EditData.Link,
                        ImageUrl = EditData.ImageUrl,
                        ListOfSocial = social.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new SocialMediaModel 
                {
                    CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                    EditId = userId,
                    ImageUrl = Image == "" ? model.ImageUrl : Image,
                    SocialMediaId=model.SocialMediaId,
                    PlatformName=model.PlatformName,
                    Link=model.Link,
                    
                };
                if (model.SocialMediaId == 0) { social.Add(NewData); }
                else { social.Update(model.SocialMediaId, NewData); }
                    return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, SocialMediaModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = social.Find(id);
            collection.EditId = userId;
            social.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            social.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

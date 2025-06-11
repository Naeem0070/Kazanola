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
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> setting { get; set; }
        public IClassHelper helper { get; set; }
        public SystemSettingController(IRepository<SystemSetting> setting, IClassHelper helper)
        {
            this.setting = setting;
            this.helper = helper;
        }
        public IActionResult Index(int EditId)
        {
            SystemSetting EditData =new();
            if (EditId > 0) { EditData = setting.Find(EditId); }
            var ViewObj = new SystemSettingVM 
            {
                Email=EditData.Email,
                FooterNote=EditData.FooterNote,
                Location=EditData.Location,
                LogoUrl=EditData.LogoUrl,
                PhomeNumber=EditData.PhomeNumber,
                SystemSettingId=EditData.SystemSettingId,
                ListOfSetting=setting.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, SystemSettingVM model)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string Image = helper.SaveImage(model.LogoFile, "Logo_image");
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "املا كل الحقول");
                    SystemSetting EditData = new();
                    if (EditId > 0) { EditData = setting.Find(EditId); }
                    var ViewObj = new SystemSettingVM
                    {
                        Email = EditData.Email,
                        FooterNote = EditData.FooterNote,
                        Location = EditData.Location,
                        LogoUrl = EditData.LogoUrl,
                        PhomeNumber = EditData.PhomeNumber,
                        SystemSettingId = EditData.SystemSettingId,
                        ListOfSetting = setting.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new SystemSetting
                {
                    CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                    EditId = userId,
                    LogoUrl = Image == "" ? model.LogoUrl : Image,
                    Location= model.Location,
                    PhomeNumber= model.PhomeNumber,
                    FooterNote = model.FooterNote,
                    Email = model.Email,
                    SystemSettingId = model.SystemSettingId
                  

                };
                if (model.SystemSettingId == 0) { setting.Add(NewData); }
                else { setting.Update(model.SystemSettingId, NewData); }
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, SystemSetting collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = setting.Find(id);
            collection.EditId = userId;
            setting.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            setting.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

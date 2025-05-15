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
    public class FAQController : Controller
    {
        public IRepository<FAQModel> faq { get; set; }
        public FAQController(IRepository<FAQModel>? faq)
        {
            this.faq= faq;
        }
        public IActionResult Index(int EditId)
        {
            FAQModel EditData = new FAQModel();
            if(EditId > 0)
            {
                EditData = faq.Find(EditId);
            }
            var ViewObject = new FAQViewModel
            {
                FAQList = faq.View(),
                FAQId = EditData.FAQId,
                Question = EditData.Question,
                Answer = EditData.Answer
            };
            return View(ViewObject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FAQViewModel model,int EditId)
        {

            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "الرجاء التحقق من البيانات المدخلة");
                    FAQModel EditData = new FAQModel();
                    if (EditId > 0)
                    {
                        EditData = faq.Find(EditId);
                    }
                    var ViewObject = new FAQViewModel
                    {
                        FAQList = faq.View(),
                        FAQId = EditData.FAQId,
                        Question = EditData.Question,
                        Answer = EditData.Answer,
                        CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                        EditId = userId,
                    };
                    return View(ViewObject);
                }

                FAQModel data = new FAQModel
                {
                    FAQId = model.FAQId,
                    Question = model.Question,
                    Answer = model.Answer,
                    CreateId = string.IsNullOrEmpty(model.CreateId) ? userId : model.CreateId,
                    EditId = userId,
                };
                if (model.FAQId > 0)
                {
                    faq.Update(model.FAQId, data);
                }
                else
                {
                    faq.Add(data);
                }

                return RedirectToAction("Index");
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
        public ActionResult Delete(int id, FAQModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = faq.Find(id);
            collection.EditId = userId;
            faq.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            faq.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

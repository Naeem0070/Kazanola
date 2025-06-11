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
    public class TermsController : Controller
    {
        public IRepository<Terms_ConditionsModel> TermsList { get; set; }
        public TermsController(IRepository<Terms_ConditionsModel> TermsList)
        {
            this.TermsList = TermsList;
        }
        public IActionResult Index(int EditId)
        {
            Terms_ConditionsModel EditData = new Terms_ConditionsModel();
            if (EditId > 0) { EditData = TermsList.Find(EditId); }
            var ViewObj = new Terms_ConditionsVM
            {
                Terms_ConditionsId = EditData.Terms_ConditionsId,
                Title = EditData.Title,
                Description = EditData.Description,
                TermsList = TermsList.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(int EditId,Terms_ConditionsVM collection) 
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("", "املاء كل الحقول");
                    Terms_ConditionsModel EditData = new Terms_ConditionsModel();
                    if (EditId > 0) { EditData = TermsList.Find(EditId); }
                    var ViewObj = new Terms_ConditionsVM
                    {
                        Terms_ConditionsId = EditData.Terms_ConditionsId,
                        Title = EditData.Title,
                        Description = EditData.Description,
                        TermsList = TermsList.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new Terms_ConditionsModel 
                {
                    Terms_ConditionsId=collection.Terms_ConditionsId,
                    Title=collection.Title,
                    Description = collection.Description,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                };
                if (collection.Terms_ConditionsId == 0)
                {
                    TermsList.Add(NewData);
                }
                else { TermsList.Update(collection.Terms_ConditionsId,NewData);}
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, Terms_ConditionsModel collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = TermsList.Find(id);
            collection.EditId = userId;
            TermsList.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            TermsList.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

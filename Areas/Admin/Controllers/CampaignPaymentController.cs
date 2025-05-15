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
    public class CampaignPaymentController : Controller
    {
        public IRepository<Page> page { get; set; }
        public IRepository<CampaignPayment> pay { get; set; }
        public CampaignPaymentController(IRepository<CampaignPayment> pay, IRepository<Page> page)
        {
            this.page = page;
            this.pay = pay;
        }
        public IActionResult Calculate() 
        {
            var EditData = new CampaignPayment();
            var ViewObj = new CampaignPaymentViewModel
            {
                CampaignPaymentID = EditData.CampaignPaymentID,
                CampaignName = EditData.CampaignName,
                PageID = EditData.PageID,
                Payment = EditData.Payment,
                PaymentDate = EditData.PaymentDate,
                CampaignPaymentList = pay.View(),
                PageList = page.View()
            };
            return View(ViewObj);
        }
        public IActionResult Index(int EditId)
        {
            CampaignPayment EditData = new();
            if (EditId != 0) {
                EditData = pay.Find(EditId);
            }
            var ViewObj = new CampaignPaymentViewModel
            {
                CampaignPaymentID = EditData.CampaignPaymentID,
                CampaignName = EditData.CampaignName,
                PageID = EditData.PageID,
                Payment = EditData.Payment,
                PaymentDate = EditData.PaymentDate,
                CampaignPaymentList = pay.View(),
                PageList = page.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, CampaignPaymentViewModel collection)
        {


            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    CampaignPayment EditData = new();
                    if (EditId != 0)
                    {
                        EditData = pay.Find(EditId);
                    }
                    var ViewObj = new CampaignPaymentViewModel
                    {
                        CampaignPaymentID = EditData.CampaignPaymentID,
                        CampaignName = EditData.CampaignName,
                        PageID = EditData.PageID,
                        Payment = EditData.Payment,
                        PaymentDate = EditData.PaymentDate,
                        CampaignPaymentList = pay.View(),
                        PageList = page.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new CampaignPayment
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    PageID=collection.PageID,
                    CampaignName=collection.CampaignName,
                    Payment = collection.Payment,
                    PaymentDate = collection.PaymentDate,
                    CampaignPaymentID = collection.CampaignPaymentID
                };
                if (collection.CampaignPaymentID == 0)
                {
                    pay.Add(NewData);
                }
                else
                {
                    pay.Update(collection.CampaignPaymentID, NewData);
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
        public ActionResult Delete(int id, CampaignPayment collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = pay.Find(id);
            collection.EditId = userId;
            pay.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            pay.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace Kazanola.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BillPaymentController : Controller
    {

        public IRepository<BillPayment> billPya { get; set; }
        public IRepository<ScheduleBill> bill { get; set; }
        public IUserRepository<Users> Users { get; set; }
        public BillPaymentController(IRepository<BillPayment> billPya,IRepository<ScheduleBill> bill,IUserRepository<Users> user)
        {
            this.billPya = billPya;
            this.bill = bill;
            Users= user;
        }
        public IActionResult Index(int EditId)
        {
            BillPayment EditData = new BillPayment();
            if (EditId != 0)
            {
                EditData = billPya.Find(EditId);
                
            }
            var ViewObj = new BillPaymentViewModel { 
            BillPaymentID=EditData.BillPaymentID,
                BillID = EditData.BillID,
                PaymentAmount = EditData.PaymentAmount,
                PaymentMethod = EditData.PaymentMethod,
                BillPaymentDate = EditData.BillPaymentDate,
                BillPaymentsList = billPya.View(),
                ScheduleBillsList=bill.View()
            };

            
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, BillPaymentViewModel collection)
        {
           

            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    BillPayment EditData = new BillPayment();
                    if (EditId != 0)
                    {
                        EditData = billPya.Find(EditId);
                       
                    }
                    var ViewObj = new BillPaymentViewModel
                    {
                        BillPaymentID = EditData.BillPaymentID,
                        BillID = EditData.BillID,
                        PaymentAmount = EditData.PaymentAmount,
                        PaymentMethod = EditData.PaymentMethod,
                        BillPaymentDate = EditData.BillPaymentDate,
                        BillPaymentsList = billPya.View(),
                        ScheduleBillsList = bill.View()
                    };

                    
                    return View(ViewObj);
                }
                var NewData = new BillPayment
                {
                    BillID = collection.BillID,
                    PaymentAmount = collection.PaymentAmount,
                    PaymentMethod = collection.PaymentMethod,
                    BillPaymentDate = collection.BillPaymentDate,
                    BillPaymentID = collection.BillPaymentID,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,

                };
                if (collection.BillPaymentID == 0)
                {
                    billPya.Add(NewData);
                }
                else
                {
                    billPya.Update(collection.BillPaymentID, NewData);
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
        public ActionResult Delete(int id, BillPayment collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = billPya.Find(id);
            collection.EditId = userId;
            billPya.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            billPya.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

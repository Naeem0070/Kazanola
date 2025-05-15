using Kazanola.Areas.Admin.Controllers;
using Kazanola.Models.Repositories;
using Kazanola.Models;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Authorization;

namespace Kazanola.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ScheduleBillController : Controller
    {
        
        public IRepository<ScheduleBill> bill { get; set; }
        public IUserRepository<Users> Users { get; set; }
        public ScheduleBillController(IRepository<ScheduleBill> bill, IUserRepository<Users> user)
        {

            this.bill = bill;
            Users = user;
        }
        public IActionResult Index(int EditId)
        {
            ScheduleBill EditData = new ScheduleBill();
            if (EditId != 0)
            {
                EditData = bill.Find(EditId);
                
            }

            var data = new ScheduleBillViewModel
            {
                ScheduleBillID = EditData.ScheduleBillID,
                BillDate = EditData.BillDate,
                BillCost = EditData.BillCost,
                BillCompany = EditData.BillCompany,
                BillNumber = EditData.BillNumber,
                ScheduleBillList = bill.View() 
            };

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, ScheduleBillViewModel collection)
        {
           
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    ScheduleBill EditData = new ScheduleBill();
                    if (EditId != 0)
                    {
                        EditData = bill.Find(EditId);
                        
                    }

                    var data = new ScheduleBillViewModel
                    {
                        ScheduleBillID = EditData.ScheduleBillID,
                        BillDate = EditData.BillDate,
                        BillCost = EditData.BillCost,
                        BillCompany = EditData.BillCompany,
                        BillNumber = EditData.BillNumber,
                        ScheduleBillList = bill.View() 
                    };

                    return View(data);
                }
                var NewData = new ScheduleBill
                {
                    BillCompany = collection.BillCompany,
                    BillCost = collection.BillCost,
                    BillDate = collection.BillDate,
                    ScheduleBillID = collection.ScheduleBillID,
                    BillNumber = collection.BillNumber,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                };
                if (collection.ScheduleBillID == 0)
                {
                    bill.Add(NewData);
                }
                else
                {
                    bill.Update(collection.ScheduleBillID, NewData);
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
        public ActionResult Delete(int id, ScheduleBill collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = bill.Find(id);
            collection.EditId = userId;
            bill.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            bill.Active(id);

            return RedirectToAction(nameof(Index));
        }

    }
}




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
    public class EmployeeWithdrawalController : Controller
    {
        public IRepository<EmployeeWithdrawal> drawal { get; set; }
        public IRepository<Employee> emp { get; set; }
        public EmployeeWithdrawalController(IRepository<EmployeeWithdrawal> _drawal, IRepository<Employee> _emp)
        {
            drawal = _drawal;
            emp = _emp;
        }

        public IActionResult Calculate()
        {
            EmployeeWithdrawal EditData = new EmployeeWithdrawal();
            var ViewObj = new EmployeeWithdrawalViewModel
            {
                EmployeeID = EditData.EmployeeID,
                EmployeeWithdrawalID = EditData.EmployeeWithdrawalID,
                WithdrawalAmount = EditData.WithdrawalAmount,
                WithdrawalDate = EditData.WithdrawalDate,
                Details = EditData.Details,
                EmployeeList = emp.View(),
                EmployeeWithdrawalList = drawal.View(),
            };
            return View(ViewObj);
        }
        public IActionResult Index(int EditId)
        {
            EmployeeWithdrawal EditData = new EmployeeWithdrawal();
            if (EditId != 0)
            {
                EditData = drawal.Find(EditId);
            }
            var ViewObj = new EmployeeWithdrawalViewModel
            {
                EmployeeID = EditData.EmployeeID,
                EmployeeWithdrawalID = EditData.EmployeeWithdrawalID,
                WithdrawalAmount = EditData.WithdrawalAmount,
                WithdrawalDate = EditData.WithdrawalDate,
                Details = EditData.Details,
                EmployeeList = emp.View(),
                EmployeeWithdrawalList = drawal.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, EmployeeWithdrawalViewModel collection)
        {


            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    EmployeeWithdrawal EditData = new EmployeeWithdrawal();
                    if (EditId != 0)
                    {
                        EditData = drawal.Find(EditId);
                    }
                    var ViewObj = new EmployeeWithdrawalViewModel
                    {
                        EmployeeID = EditData.EmployeeID,
                        EmployeeWithdrawalID = EditData.EmployeeWithdrawalID,
                        WithdrawalAmount = EditData.WithdrawalAmount,
                        WithdrawalDate = EditData.WithdrawalDate,
                        Details = EditData.Details,
                        EmployeeList = emp.View(),
                        EmployeeWithdrawalList = drawal.View(),
                    };
                    return View(ViewObj);
                }
                var NewData = new EmployeeWithdrawal
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    EmployeeID = collection.EmployeeID,
                    WithdrawalAmount = collection.WithdrawalAmount,
                    WithdrawalDate = collection.WithdrawalDate,
                    EmployeeWithdrawalID = collection.EmployeeWithdrawalID,
                    Details = collection.Details,
                };
               
                if (collection.EmployeeWithdrawalID == 0)
                {
                    drawal.Add(NewData);
                }
                else
                {
                    drawal.Update(collection.EmployeeWithdrawalID, NewData);
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
        public ActionResult Delete(int id, EmployeeWithdrawal collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = drawal.Find(id);
            collection.EditId = userId;
            drawal.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            drawal.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

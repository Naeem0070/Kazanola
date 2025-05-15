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
    public class EmployeeController : Controller
    {
        public IRepository<Employee> emp { get; set; }
        public EmployeeController(IRepository<Employee> emp)
        {
            this.emp = emp;
        }
        public IActionResult Index(int EditId)
        {
            Employee EditData = new Employee();
            if (EditId > 0)
            {
                EditData = emp.Find(EditId);
            }
            var ViewObject = new EmployeeViewModel()
            {
                EmployeeID = EditData.EmployeeID,
                EmployeeName = EditData.EmployeeName,
                Salary = EditData.Salary,
                HourlyRate = EditData.HourlyRate,
                EmployeesList=emp.View()
            };
            return View(ViewObject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, EmployeeViewModel collection)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    Employee EditData = new Employee();
                    if (EditId > 0)
                    {
                        EditData = emp.Find(EditId);
                    }
                    var ViewObject = new EmployeeViewModel()
                    {
                        EmployeeID = EditData.EmployeeID,
                        EmployeeName = EditData.EmployeeName,
                        Salary = EditData.Salary,
                        HourlyRate = EditData.HourlyRate,
                        EmployeesList = emp.View()
                    };
                    return View(ViewObject);
                }
                var data = new Employee
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    EmployeeName = collection.EmployeeName,
                    Salary = collection.Salary,
                    HourlyRate = collection.HourlyRate,
                    EmployeeID = collection.EmployeeID,
                };
                
                
                if (collection.EmployeeID == 0)
                {
                    emp.Add(data);
                }
                else
                {
                    emp.Update(collection.EmployeeID, data);
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
        public ActionResult Delete(int id, Employee collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = emp.Find(id);
            collection.EditId = userId;
            emp.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            emp.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

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
    public class EmployeeScheduleController : Controller
    {
        public IRepository<Employee> emp { get; set; }
        public IRepository<EmployeeSchedule> schedule { get; set; }
        public EmployeeScheduleController(IRepository<Employee> emp, IRepository<EmployeeSchedule> schedule)
        {
            this.emp = emp;
            this.schedule = schedule;
        }
        public IActionResult Calculate()
        {
            EmployeeSchedule EditData = new();
            var ViewObj = new EmployeeScheduleViewModel
            {
                EmployeeID = EditData.EmployeeID,
                StartTime = EditData.StartTime,
                EndTime = EditData.EndTime,
                
                Hours = EditData.Hours,
                EmployeeScheduleID = EditData.EmployeeScheduleID,
                EmployeeSchedulesList = schedule.View(),
                EmployeesList = emp.View(),
            };
            return View(ViewObj);
        }
        public IActionResult Index(int EditId)
        {
            EmployeeSchedule EditData = new();
            if (EditId > 0)
            {
                EditData = schedule.Find(EditId);
            }
            var ViewObj = new EmployeeScheduleViewModel
            {
                EmployeeID = EditData.EmployeeID,
                StartTime = EditData.StartTime,
                EndTime = EditData.EndTime,
                
                Hours = EditData.Hours,
                EmployeeScheduleID = EditData.EmployeeScheduleID,
                EmployeeSchedulesList = schedule.View(),
                EmployeesList = emp.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, EmployeeScheduleViewModel collection)
        {


            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    EmployeeSchedule EditData = new();
                    if (EditId > 0)
                    {
                        EditData = schedule.Find(EditId);
                    }
                    var ViewObj = new EmployeeScheduleViewModel
                    {
                        EmployeeID = EditData.EmployeeID,
                        StartTime = EditData.StartTime,
                        EndTime = EditData.EndTime,
                        
                        Hours = EditData.Hours,
                        EmployeeScheduleID = EditData.EmployeeScheduleID,
                        EmployeeSchedulesList = schedule.View(),
                        EmployeesList = emp.View(),
                    };
                    return View(ViewObj);
                }
                var NewData = new EmployeeSchedule
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    EmployeeID = collection.EmployeeID,
                    StartTime = collection.StartTime,
                    EndTime = collection.EndTime,
                    
                    Hours = collection.EndTime.HasValue && collection.StartTime.HasValue
                    ? (decimal)(collection.EndTime.Value - collection.StartTime.Value).TotalHours: 0,
                    EmployeeScheduleID = collection.EmployeeScheduleID,

                };
                if (collection.EmployeeScheduleID == 0)
                {
                    schedule.Add(NewData);
                }
                else
                {
                    schedule.Update(collection.EmployeeScheduleID, NewData);
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
        public ActionResult Delete(int id, EmployeeSchedule collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = schedule.Find(id);
            collection.EditId = userId;
            schedule.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            schedule.Active(id);

            return RedirectToAction(nameof(Index));
        }

    }
}

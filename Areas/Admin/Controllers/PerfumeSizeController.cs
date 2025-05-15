using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Kazanola.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PerfumeSizeController : Controller
    {
        public IRepository<PerfumeSize> size { get; set; }
        public PerfumeSizeController(IRepository<PerfumeSize> size)
        {
            this.size= size;
        }

        public IActionResult Index(int EditId)
        {
            PerfumeSize EditData = new();
            if (EditId!=0) 
            {
                EditData = size.Find(EditId);
            }
            var ViewObj = new PerfumeSizeVM
            {
              PerfumeSizeId=EditData.PerfumeSizeId,
                Size=EditData.Size,
                Cost=EditData.Cost,
                SizeList=size.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId , PerfumeSizeVM collection) 
        {
            try 
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    PerfumeSize EditData = new();
                    if (EditId != 0)
                    {
                        EditData = size.Find(EditId);
                    }
                    var ViewObj = new PerfumeSizeVM
                    {
                        PerfumeSizeId = EditData.PerfumeSizeId,
                        Size = EditData.Size,
                        Cost = EditData.Cost,
                        SizeList = size.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new PerfumeSize 
                {
                    PerfumeSizeId=collection.PerfumeSizeId,
                    Size=collection.Size,
                    Cost=collection.Cost,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                };
                if (collection.PerfumeSizeId == 0)
                {
                    size.Add(NewData);
                }
                else
                {
                    size.Update(collection.PerfumeSizeId,NewData);
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
        public ActionResult Delete(int id, PerfumeSize collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = size.Find(id);
            collection.EditId = userId;
            size.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            size.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

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

    public class PerfumeDetailsController : Controller
    {
        public IPerfumeReposetory<PerfumeDetails> perfume{ get; set; }
        public IRepository<Product> product { get; set; }

        public IClassHelper helper { get; set; }
        public PerfumeDetailsController(IRepository<PerfumeSize> size, IRepository<Product> product, IPerfumeReposetory<PerfumeDetails> perfume, IClassHelper helper)
        {
          
            this.product = product;
            this.perfume = perfume;
            this.helper = helper;
        }
        public IActionResult Index(int EditId)
        {
            PerfumeDetails EditData = new PerfumeDetails();
            if (EditId != 0)
            {
                EditData = perfume.Find(EditId);
            }
            var ViewObj = new PerfumeDetailsVM
            {
                PerfumeDetailsId = EditData.PerfumeDetailsId,
                ProductId = EditData.ProductId,
                ProductDiscreption = EditData.ProductDiscreption,
                ProductType = EditData.ProductType,
         

                ProductImage1 = EditData.ProductImage1,
                ProductImage2 = EditData.ProductImage2,
                ProductImage3 = EditData.ProductImage3,
                ProductImage4 = EditData.ProductImage4,
                ProductImage5 = EditData.ProductImage5,
                ProductImage6 = EditData.ProductImage6,
            
                ProductsList = product.View(),
                PerfumeDetailsList = perfume.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, PerfumeDetailsVM collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "يرجى تعبئة جميع الحقول المطلوبة");
                return View(PrepareViewModel(EditId));
            }

            string ImageUrl1 = helper.SaveImage(collection.FileImage1, "ProductImage");
            string ImageUrl2 = helper.SaveImage(collection.FileImage2, "ProductImage");
            string ImageUrl3 = helper.SaveImage(collection.FileImage3, "ProductImage");
            string ImageUrl4 = helper.SaveImage(collection.FileImage4, "ProductImage");
            string ImageUrl5 = helper.SaveImage(collection.FileImage5, "ProductImage");
            string ImageUrl6 = helper.SaveImage(collection.FileImage6, "ProductImage");
            var newData = new PerfumeDetails
            {
                PerfumeDetailsId = collection.PerfumeDetailsId,
                ProductId = collection.ProductId,
                ProductDiscreption = collection.ProductDiscreption,
                ProductType = collection.ProductType,
      
                OutOfStock = collection.OutOfStock,
                ProductImage1 = string.IsNullOrEmpty(ImageUrl1) ? collection.ProductImage1 : ImageUrl1,
                ProductImage2 = string.IsNullOrEmpty(ImageUrl2) ? collection.ProductImage2 : ImageUrl2,
                ProductImage3 = string.IsNullOrEmpty(ImageUrl3) ? collection.ProductImage3 : ImageUrl3,
                ProductImage4 = string.IsNullOrEmpty(ImageUrl4) ? collection.ProductImage4 : ImageUrl4,
                ProductImage5 = string.IsNullOrEmpty(ImageUrl5) ? collection.ProductImage5 : ImageUrl5,
                ProductImage6 = string.IsNullOrEmpty(ImageUrl6) ? collection.ProductImage6 : ImageUrl6,
                CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                EditId = userId
            };

            if (collection.PerfumeDetailsId == 0)
                perfume.Add(newData);
            else
                perfume.Update(collection.PerfumeDetailsId, newData);

            return RedirectToAction(nameof(Index));
        }

        private PerfumeDetailsVM PrepareViewModel(int EditId)
        {
            PerfumeDetails data = EditId != 0 ? perfume.Find(EditId) : new PerfumeDetails();
            return new PerfumeDetailsVM
            {
                PerfumeDetailsId = data.PerfumeDetailsId,
                ProductId = data.ProductId,
                ProductDiscreption = data.ProductDiscreption,
                ProductType = data.ProductType,
           
                OutOfStock = data.OutOfStock,
                ProductImage1 = data.ProductImage1,
                ProductImage2 = data.ProductImage2,
                ProductImage3 = data.ProductImage3,
                ProductImage4 = data.ProductImage4,
                ProductImage5 = data.ProductImage5,
                ProductImage6 = data.ProductImage6,
            
                ProductsList = product.View(),
                PerfumeDetailsList = perfume.View()
            };
        }

        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, PerfumeDetails collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = perfume.Find(id);
            collection.EditId = userId;
            perfume.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            perfume.Active(id);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Update_OutOfStock(int id)
        {

            perfume.OutOfStoke(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

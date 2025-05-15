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
        public IRepository<PerfumeSize> size { get; set; }
        public IClassHelper helper { get; set; }
        public PerfumeDetailsController(IRepository<PerfumeSize> size, IRepository<Product> product, IPerfumeReposetory<PerfumeDetails> perfume, IClassHelper helper)
        {
            this.size = size;
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
                PerfumeSizeId = EditData.PerfumeSizeId,

                ProductImage1 = EditData.ProductImage1,
                ProductImage2 = EditData.ProductImage2,
                ProductImage3 = EditData.ProductImage3,
                ProductImage4 = EditData.ProductImage4,
                ProductImage5 = EditData.ProductImage5,
                ProductImage6 = EditData.ProductImage6,
                PerfumeSizesList = size.View(),
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

            var images = new string?[6];
            var files = new IFormFile?[] {
        collection.FileImage1, collection.FileImage2, collection.FileImage3,
        collection.FileImage4, collection.FileImage5, collection.FileImage6
    };
            var currentImages = new string?[] {
        collection.ProductImage1, collection.ProductImage2, collection.ProductImage3,
        collection.ProductImage4, collection.ProductImage5, collection.ProductImage6
    };

            for (int i = 0; i < 6; i++)
            {
                string? uploadedImage = helper.SaveImage(files[i], "PerfumeImage");
                images[i] = string.IsNullOrEmpty(uploadedImage) ? currentImages[i] : uploadedImage;
            }

            var newData = new PerfumeDetails
            {
                PerfumeDetailsId = collection.PerfumeDetailsId,
                ProductId = collection.ProductId,
                ProductDiscreption = collection.ProductDiscreption,
                ProductType = collection.ProductType,
                PerfumeSizeId = collection.PerfumeSizeId,
                OutOfStock = collection.OutOfStock,
                ProductImage1 = images[0],
                ProductImage2 = images[1],
                ProductImage3 = images[2],
                ProductImage4 = images[3],
                ProductImage5 = images[4],
                ProductImage6 = images[5],
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
                PerfumeSizeId = data.PerfumeSizeId,
                OutOfStock = data.OutOfStock,
                ProductImage1 = data.ProductImage1,
                ProductImage2 = data.ProductImage2,
                ProductImage3 = data.ProductImage3,
                ProductImage4 = data.ProductImage4,
                ProductImage5 = data.ProductImage5,
                ProductImage6 = data.ProductImage6,
                PerfumeSizesList = size.View(),
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

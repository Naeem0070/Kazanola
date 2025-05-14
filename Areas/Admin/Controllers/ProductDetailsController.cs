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
    public class ProductDetailsController : Controller
    {
        public IRepository<ProductDetails> PD { get; set; }
        public IRepository<Product> P { get; set; }
        public IClassHelper helper { get; set; }
        public ProductDetailsController(IRepository<ProductDetails> PD, IClassHelper helper, IRepository<Product> P)
        {
            this.PD = PD;
            this.helper = helper;
            this.P = P;
        }
        public IActionResult Index(int EditId)
        {
            ProductDetails EditData = new ProductDetails();
            if (EditId != 0) 
            {
                EditData= PD.Find(EditId);
            }
            var ViewObj = new ProductDetailsVM
            {
                ProductDetailsId=EditData.ProductDetailsId,
                ProductDiscreption=EditData.ProductDiscreption,
                ProductId = EditData.ProductId,
                ProductImage1 = EditData.ProductImage1,
                ProductImage2 = EditData.ProductImage2,
                ProductImage3 = EditData.ProductImage3,
                ProductImage4 = EditData.ProductImage4,
                ProductImage5 = EditData.ProductImage5,
                ProductImage6 = EditData.ProductImage6,
                ProductDetails = PD.View(),
                Products = P.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId,ProductDetailsVM collection)
        {
            try 
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid) {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    ProductDetails EditData = new ProductDetails();
                    if (EditId != 0)
                    {
                        EditData = PD.Find(EditId);
                    }
                    var ViewObj = new ProductDetailsVM
                    {
                        ProductDetailsId = EditData.ProductDetailsId,
                        ProductDiscreption = EditData.ProductDiscreption,
                        ProductId = EditData.ProductId,
                        ProductImage1 = EditData.ProductImage1,
                        ProductImage2 = EditData.ProductImage2,
                        ProductImage3 = EditData.ProductImage3,
                        ProductImage4 = EditData.ProductImage4,
                        ProductImage5 = EditData.ProductImage5,
                        ProductImage6 = EditData.ProductImage6,
                        ProductDetails = PD.View(),
                        Products = P.View(),
                    };
                    return View(ViewObj);
                }
               string ImageUrl1= helper.SaveImage(collection.FileImage1, "ProductImage");
               string ImageUrl2= helper.SaveImage(collection.FileImage2, "ProductImage");
               string ImageUrl3= helper.SaveImage(collection.FileImage3, "ProductImage");
               string ImageUrl4= helper.SaveImage(collection.FileImage4, "ProductImage");
               string ImageUrl5= helper.SaveImage(collection.FileImage5, "ProductImage");
               string ImageUrl6= helper.SaveImage(collection.FileImage6, "ProductImage");

                var NewData = new ProductDetails
                {
                    ProductDetailsId=collection.ProductDetailsId,
                    ProductDiscreption=collection.ProductDiscreption,
                    ProductId=collection.ProductId,
                    ProductImage1 = string.IsNullOrEmpty(ImageUrl1) ? collection.ProductImage1 : ImageUrl1,
                    ProductImage2 = string.IsNullOrEmpty(ImageUrl2) ? collection.ProductImage2 : ImageUrl2,
                    ProductImage3 = string.IsNullOrEmpty(ImageUrl3) ? collection.ProductImage3 : ImageUrl3,
                    ProductImage4 = string.IsNullOrEmpty(ImageUrl4) ? collection.ProductImage4 : ImageUrl4,
                    ProductImage5 = string.IsNullOrEmpty(ImageUrl5) ? collection.ProductImage5 : ImageUrl5,
                    ProductImage6 = string.IsNullOrEmpty(ImageUrl6) ? collection.ProductImage6 : ImageUrl6,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,

                };
                if(collection.ProductDetailsId==0)
                    PD.Add(NewData);
                else
                {
                    PD.Update(collection.ProductDetailsId,NewData);
                }
                return RedirectToAction(nameof(Index));
            }
            catch { return View(); }
        }

        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, ProductDetails collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = PD.Find(id);
            collection.EditId = userId;
            PD.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {
         
            PD.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

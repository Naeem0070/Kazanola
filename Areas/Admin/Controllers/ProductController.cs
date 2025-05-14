using Kazanola.Areas.Admin.MyClass;
using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace Kazanola.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IRepository<Product> product { get; set; }
        public IRepository<Brand> brand { get; set; }
        public IRepository<ScheduleBill> bill { get; set; }
        public IClassHelper HelperClass { get; }
        public ProductController(IRepository<Product> product, IRepository<Brand> brand,
            IRepository<ScheduleBill> bill, IClassHelper HelperClass)
        {
            this.product = product;
            this.brand = brand;
            this.bill = bill;
            this.HelperClass = HelperClass;
        }
        public IActionResult Index(int EditId)
        {
            Product EditData = new Product();
            if (EditId != 0) 
            {
                EditData = product.Find(EditId);
            }
            var ViewObj = new ProductViewModel 
            {
                ProductID=EditData.ProductID,
                ProductName=EditData.ProductName,
                ProductCost=EditData.ProductCost,
                ProductPrice = EditData.ProductPrice,
                Benefit = EditData.Benefit,
                BillID = EditData.BillID,
                BrandId = EditData.BrandId,
                ProductImageUrl = EditData.ProductImageUrl,
                ProductCostAfterBay= EditData.ProductCostAfterBay,
                ProductList=product.View(),
                BrandList=brand.View(),
                ScheduleBillList=bill.View(),
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, ProductViewModel collection)
        {


            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    Product EditData = new Product();
                    if (EditId != 0)
                    {
                        EditData = product.Find(EditId);
                    }
                    var ViewObj = new ProductViewModel
                    {
                        ProductID = EditData.ProductID,
                        ProductName = EditData.ProductName,
                        ProductCost = EditData.ProductCost,
                        ProductPrice = EditData.ProductPrice,
                        Benefit = EditData.Benefit,
                        BillID = EditData.BillID,
                        BrandId = EditData.BrandId,
                        ProductImageUrl = EditData.ProductImageUrl,
                        ProductCostAfterBay= EditData.ProductCostAfterBay,
                        ProductList = product.View(),
                        BrandList = brand.View(),
                        ScheduleBillList = bill.View(),
                    };
                    return View(ViewObj);
                }
                string ImageURL= HelperClass.SaveImage(collection.ProductImageFile, "Product_img");
                var NewData = new Product
                {
                    ProductID = collection.ProductID,
                    ProductName = collection.ProductName,
                    ProductCost = collection.ProductCost,
                    ProductPrice = collection.ProductPrice,
                    ProductCostAfterBay = collection.ProductCostAfterBay,
                    Benefit = collection.ProductPrice-collection.ProductCostAfterBay,
                    BillID = collection.BillID,
                    BrandId = collection.BrandId,
                    ProductImageUrl = ImageURL==""?collection.ProductImageUrl:ImageURL,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                };
                
                if (collection.ProductID == 0)
                {
                    product.Add(NewData);
                }
                else
                {
                    product.Update(collection.ProductID, NewData);
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
        public ActionResult Delete(int id, Product collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = product.Find(id);
            collection.EditId = userId;
            product.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            product.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

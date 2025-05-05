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
    public class OrderDetailController : Controller
    {
        public IRepository<OrderDetail> detail{ get; set; }
        public IOrderRepository<Order> order{ get; set; }
        public IRepository<Product> product { get; set; }
        public OrderDetailController(IRepository<OrderDetail> detail, IOrderRepository<Order> order, IRepository<Product> product)
        {
            this.detail = detail;
            this.order = order;
            this.product = product;
        }

        public IActionResult Index(int EditId)
        {
            OrderDetail EditData = new();
            if (EditId != 0) { EditData = detail.Find(EditId); }
            var ViewObj = new OrderDetailsViewModel
            {
                OrderDetailID=EditData.OrderDetailID,
                OrderID = EditData.OrderID,
                ProductID = EditData.ProductID,
                Quantity = EditData.Quantity,
                ProductSalePrice = EditData.ProductSalePrice,
                TotalPrice = EditData.TotalPrice,
                OrderDetailsList = detail.View(),
                OrderList = order.View(),
                ProductList = product.View()
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, OrderDetailsViewModel collection)
        {


            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    OrderDetail EditData = new();
                    if (EditId != 0) { EditData = detail.Find(EditId); }
                    var ViewObj = new OrderDetailsViewModel
                    {
                        OrderDetailID = EditData.OrderDetailID,
                        OrderID = EditData.OrderID,
                        ProductID = EditData.ProductID,
                        Quantity = EditData.Quantity,
                        ProductSalePrice = EditData.ProductSalePrice,
                        TotalPrice = EditData.TotalPrice,
                        OrderDetailsList = detail.View(),
                        OrderList = order.View(),
                        ProductList = product.View()
                    };
                    return View(ViewObj);
                }
                var NewData = new OrderDetail
                {
                    OrderDetailID = collection.OrderDetailID,
                    OrderID = collection.OrderID,
                    ProductID = collection.ProductID,
                    Quantity = collection.Quantity,
                    ProductSalePrice = collection.ProductSalePrice,
                    TotalPrice = collection.Quantity*collection.ProductSalePrice,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,

                };
                if (collection.OrderDetailID == 0)
                {
                    detail.Add(NewData);
                }
                else
                {
                    detail.Update(collection.OrderDetailID, NewData);
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
        public ActionResult Delete(int id, OrderDetail collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = detail.Find(id);
            collection.EditId = userId;
            detail.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            detail.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

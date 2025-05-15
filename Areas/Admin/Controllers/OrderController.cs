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
    public class OrderController : Controller
    {
        public IOrderRepository<Order> order { get; set; }
        public IRepository<Page> page { get; set; }
        public OrderController(IOrderRepository<Order> order, IRepository<Page> page)
        {
            this.order = order;
            this.page = page;
        }
        public IActionResult Index(int EditId)
        {
            Order EditData = new Order();
            if(EditId != 0) 
            {
                EditData = order.Find(EditId);
            }
            var ViewObj = new OrderViewModel
            {
                OrderList = order.View(),
                PageList = page.View(),
                OrderID = EditData.OrderID,
                OrderTotalPrice = EditData.OrderTotalPrice,
                CustomerName = EditData.CustomerName,
                DeliveryCompany = EditData.DeliveryCompany,
                OrderDate = EditData.OrderDate,
               
                PageID = EditData.PageID,
                LocationCity = EditData.LocationCity,
                Neighborhood = EditData.Neighborhood,
                Street = EditData.Street
            };
            return View(ViewObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId, OrderViewModel collection)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please fill all the required fields");
                    Order EditData = new Order();
                    if (EditId != 0)
                    {
                        EditData = order.Find(EditId);
                    }
                    var ViewObj = new OrderViewModel
                    {
                        OrderList = order.View(),
                        PageList = page.View(),
                        OrderID = EditData.OrderID,
                        OrderTotalPrice = EditData.OrderTotalPrice,
                        CustomerName = EditData.CustomerName,
                        DeliveryCompany = EditData.DeliveryCompany,
                        OrderDate = EditData.OrderDate,
                       
                        PageID = EditData.PageID,
                        LocationCity = EditData.LocationCity,
                        Neighborhood = EditData.Neighborhood,
                        Street = EditData.Street
                    };
                    return View(ViewObj);
                }
                var data = new Order
                {
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                    OrderID = collection.OrderID,
                    OrderTotalPrice = collection.OrderTotalPrice,
                    CustomerName = collection.CustomerName,
                    DeliveryCompany = collection.DeliveryCompany,
                    OrderDate = collection.OrderDate,
                    
                    PageID = collection.PageID,
                    LocationCity = collection.LocationCity,
                    Neighborhood = collection.Neighborhood,
                    Street = collection.Street
                };
                if (collection.OrderID == 0)
                {
                    order.Add(data);
                }
                else
                {
                    order.Update(collection.OrderID, data);
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
        public ActionResult Delete(int id, Order collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = order.Find(id);
            collection.EditId = userId;
            order.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            order.Active(id);

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Update_Delivered(int id)
        {

            order.Delivered(id);

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Update_Paid(int id)
        {

            order.Paid(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

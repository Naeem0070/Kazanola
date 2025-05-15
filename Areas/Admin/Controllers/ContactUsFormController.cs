using Kazanola.Models;
using Kazanola.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kazanola.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsFormController : Controller
    {
        
        public IRepository<ContactUsForm> contact { get; set; }
        public ContactUsFormController(IRepository<ContactUsForm> contact)
        {
            this.contact = contact;
        }
        // GET: ContactUsFormController
        public ActionResult Index()
        {

            return View(contact.View());
        }

        // GET: ContactUsFormController/Details/5
        public ActionResult Details(int id)
        {
            var data = contact.Find(id);
            return View(data);
        }

       
       
       
        }
    }


using Kazanola.Areas.Admin.MyClass;
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
    public class BlogsController : Controller
    {
        public IRepository<Blogs> blogs { get; set; }
        public IClassHelper helber { get; set; }
        public BlogsController(IRepository<Blogs> blogs, IClassHelper helber)
        {
         this.blogs = blogs;
         this.helber = helber;
        }
        public IActionResult Index(int EditId)
        {
            Blogs EditData = new();
            if (EditId != 0) { EditData = blogs.Find(EditId); }
            var ViewObj = new BlogsVM
            {
                BlogsId = EditData.Id,
                StartOfBolg = EditData.StartOfBolg,
                Description = EditData.Description,
                EndOfBolg = EditData.EndOfBolg,
                ImageUrl1 = EditData.ImageUrl1,
                ImageUrl2 = EditData.ImageUrl2,
                PublishedDate = EditData.PublishedDate,
                WhoIsTheWriter = EditData.WhoIsTheWriter,
                Title = EditData.Title,
                ListOfBlogs = blogs.View()
            };
            return View(ViewObj); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int EditId,BlogsVM collection) 
        {
            try 
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid) 
                {
                    ModelState.AddModelError("","املا كل الحقول");
                    Blogs EditData = new();
                    if (EditId != 0) { EditData = blogs.Find(EditId); }
                    var ViewObj = new BlogsVM
                    {
                        BlogsId = EditData.Id,
                        StartOfBolg = EditData.StartOfBolg,
                        Description = EditData.Description,
                        EndOfBolg = EditData.EndOfBolg,
                        ImageUrl1 = EditData.ImageUrl1,
                        ImageUrl2 = EditData.ImageUrl2,
                        PublishedDate = EditData.PublishedDate,
                        WhoIsTheWriter = EditData.WhoIsTheWriter,
                        Title = EditData.Title,
                        ListOfBlogs = blogs.View()
                    };
                    return View(ViewObj);
                }
                string Image1 = helber.SaveImage(collection.FileUrl1, "Blogs_Image");
                string Image2 = helber.SaveImage(collection.FileUrl2, "Blogs_Image");
                var NewData = new Blogs 
                {
                    BlogsId=collection.BlogsId,
                    Title=collection.Title,
                    StartOfBolg=collection.StartOfBolg,
                    Description = collection.Description,
                    EndOfBolg= collection.EndOfBolg,
                    ImageUrl1 = Image1==""?collection.ImageUrl1:Image1,
                    ImageUrl2 = Image2==""?collection.ImageUrl2:Image2,
                    PublishedDate = collection.PublishedDate,
                    WhoIsTheWriter=collection.WhoIsTheWriter,
                    CreateId = string.IsNullOrEmpty(collection.CreateId) ? userId : collection.CreateId,
                    EditId = userId,
                };
                if (collection.BlogsId==0) { blogs.Add(NewData); }
                else { blogs.Update(collection.BlogsId,NewData); }
                return RedirectToAction(nameof(Index));
            } 
            catch { return View(); }
        }
        public ActionResult IndexReset()
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id, Blogs collection)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            collection = blogs.Find(id);
            collection.EditId = userId;
            blogs.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Update_Active(int id)
        {

            blogs.Active(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

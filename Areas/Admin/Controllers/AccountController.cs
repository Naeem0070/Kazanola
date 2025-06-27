using Kazanola.Areas.Admin.MyClass;
using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.MyClass;
using Kazanola.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Kazanola.Areas.Admin.Controllers
{
   
    [Area("Admin")]

    public class AccountsController : Controller
    {
        public UserManager<Users> UserManager { get; }
        public SignInManager<Users> SignInManager { get; }
        AppDbContext db;
        public IClassHelper HelperClass { get; }
        public IUserRepository<Users> repository { get; set; }


        public AccountsController(IClassHelper _HelperClass, UserManager<Users> userManager, SignInManager<Users> signInManager, AppDbContext _db,IUserRepository<Users> userRepository)
        {
            db = _db;
            UserManager = userManager;
            SignInManager = signInManager;
            HelperClass = _HelperClass;
            repository= userRepository;
           
        }

        public ActionResult Index()
        {
            //var users = UserManager.Users.Select(c => new
            //AccountViewModel()
            //{
            //    email = c.Email,
            //    username = c.Dis_Name,
            //    PassWord = c.PasswordHash,
            //    user_image = c.User_image,
            //    id = c.Id,
            //    users = repository.View()

            //});
            var data = new Users();
            var users = new AccountViewModel
            {
                email = data.Email,
                username=data.Dis_Name,
                PassWord=data.PasswordHash,
                user_image=data.User_image,
                id=data.Id,
                users=repository.View()
            };
            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var master = db.Users.Find(id);

            var data = new AccountViewModel
            {
                email = master.Email,
                username = master.Dis_Name,
                PassWord = master.PasswordHash,
                id = master.Id,
                user_image = master.User_image
            };

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(AccountViewModel collection)
        {
            string FileName = "";
            FileName = HelperClass.SaveImage(collection.File, "User_img");
            if (FileName == "")
            {
                FileName = collection.user_image;
            }
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(collection.id);

                user.Id = collection.id;
                user.PasswordHash = collection.PassWord;
                user.Email = collection.email;
                user.Dis_Name = collection.username;
                user.User_image = FileName;
                user.PasswordHash = collection.PassWord;


                var result = await UserManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }




        }
        public ActionResult Delete(string Id)
        {
            repository.Delete(Id);

            return RedirectToAction(nameof(Index));     
        }
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Register(RegisterModel collection)
        {
            try
            {
                string FileName = "";
                FileName = HelperClass.SaveImage(collection.File, "User_img");
                if (ModelState.IsValid)
                {
                    var user = new Users
                    {
                        UserName = collection.Email,
                        Email = collection.Email,
                        Dis_Name = collection.UserName,
                        User_image = FileName
                    };
                    var result = await UserManager.CreateAsync(user, collection.PassWord);
                    if (result.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(user, "Admin");
                        await SignInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction(nameof(Index));
                    }

                }
                return View(collection);

            }
            catch
            {
                return View(collection);
            }
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = await SignInManager.PasswordSignInAsync(collection.email, collection.PassWord, isPersistent: false, collection.RememberMe);

                    if (result.Succeeded)
                    {
                        /*          var iduser = UserManager.GetUserId(HttpContext.User);
                                    ApplicationUser app = UserManager.FindByIdAsync(iduser).Result;
                                    TempData["User"] = app;*/

                        return RedirectToAction("Index", "Home");

                    }

                    else
                    {
                        ModelState.AddModelError("", "Error Register");
                    }
                }
                return View(collection);

            }
            catch
            {
                return View(collection);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
       
    }
}

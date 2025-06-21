using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kazanola.Models;
using Kazanola.Models.Repositories;
using Kazanola.ViewModels;

namespace Kazanola.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public IRepository<SliderModel> slider { get; set; }
    public IRepository<Category> category { get; set; }
    public IRepository<Brand> brand { get; set; }

    public HomeController(ILogger<HomeController> logger , IRepository<SliderModel> slider, IRepository<Category> category, IRepository<Brand> brand)
    {
        _logger = logger;
        this.slider = slider;
        this.category = category;
        this.brand = brand;

    }

    public IActionResult Index()
    {
        var data = new HomeVM
        {
            SliderList = slider.ViewClient(),
            CategoryList = category.ViewClient() ,
            BrandList = brand.ViewClient(),
        };
        return View(data);
    }

  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

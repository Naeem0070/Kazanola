using Kazanola.Models;

namespace Kazanola.ViewModels
{
    public class HomeVM
    {
        public List<SliderModel>? SliderList { get; set; }
        public List<Category>? CategoryList { get; set; }
        public List<Brand>? BrandList { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TemplateImplement.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }


    }
}

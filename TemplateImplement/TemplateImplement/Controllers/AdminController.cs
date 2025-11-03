using Microsoft.AspNetCore.Mvc;

namespace TemplateImplement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

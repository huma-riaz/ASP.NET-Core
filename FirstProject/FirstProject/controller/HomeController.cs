using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace FirstProject.Controllers 
{
    public class HomeController : Controller 
    {




        // Start With Views 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public string Details(string id)
        {
            return id;
        }




     /* Only with Controller
      
    [Route("Home/Index")]
        [Route("~/")]
        public string Index()
        {
            return "Index Page";
        }

        [Route("Home/About")]
        public string About()
        {
            return "About Page";
        }

        [Route("Home/Details/{name}")]
        public string Details(string name)
        {
            return name;
        }
*/


    }
}

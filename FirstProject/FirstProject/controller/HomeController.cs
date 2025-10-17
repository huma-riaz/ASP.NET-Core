using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers 
{
    public class HomeController : Controller 
    {




        // Start With Views 
        public IActionResult Index()
        {
            return View();
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

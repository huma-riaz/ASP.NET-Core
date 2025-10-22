using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    //------------------------
    
    public IActionResult Student()
    {
        var stdlist = new List<Student>
        {
            new Student{ID=1,Name="Huma",Email="riazhuma2005@gmail.com"},
            new Student{ID=2,Name="Hassan",Email="chaudhryhassan2009@gmail.com"},
            new Student{ID=3,Name="Bilal",Email="bilalriaz@gmail.com"},
            new Student{ID=4,Name="Kiran",Email="riaz54kiran@gmail.com"}
        };
        ViewBag.stds = stdlist;

        return View();
    }

    public IActionResult People()
    {
        var stdlist = new List<Student>
        {
            new Student{ID=1,Name="Huma",Email="riazhuma2005@gmail.com"},
            new Student{ID=2,Name="Hassan",Email="chaudhryhassan2009@gmail.com"},
            new Student{ID=3,Name="Bilal",Email="bilalriaz@gmail.com"},
            new Student{ID=4,Name="Kiran",Email="riaz54kiran@gmail.com"}
        };
        ViewBag.stds = stdlist;

        return View(stdlist);
    }


    public IActionResult Add()
    {
        return View();
    }






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

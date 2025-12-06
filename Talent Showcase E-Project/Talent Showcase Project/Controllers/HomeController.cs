using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Talent_Showcase_Project.Models;

namespace Talent_Showcase_Project.Controllers;

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

    public IActionResult Movie()
    {
        return View();
    }

    public IActionResult Blog()
    {
        return View();
    }

    public IActionResult BlogDetails()
    {
        return View();
    }

    public IActionResult Celebrities()
    {
        return View();
    }

    public IActionResult MovieDetails()
    {
        return View();
    }

    public IActionResult TopMovies()
    {
        return View();
    }




    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

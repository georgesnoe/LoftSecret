using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoftSecret.Models;
using LoftSecret.ViewModels;

namespace LoftSecret.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string? loginToken = HttpContext.Request.Cookies["loginToken"];
        if (string.IsNullOrWhiteSpace(loginToken))
        {
            return View();
        }
        else
        {
            return Content("You are logged in");
        }
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

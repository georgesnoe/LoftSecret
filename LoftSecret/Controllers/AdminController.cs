using Microsoft.AspNetCore.Mvc;

namespace LoftSecret.Controllers;

public class Admin : Controller
{
    // GET: /Admin
    public IActionResult Index()
    {
        return View();
    }
}

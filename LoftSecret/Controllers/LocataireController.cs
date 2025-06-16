using Microsoft.AspNetCore.Mvc;

namespace LoftSecret.Controllers;

public class Locataire : Controller
{
    // GET: /Locataire
    public IActionResult Index()
    {
        return View();
    }
}

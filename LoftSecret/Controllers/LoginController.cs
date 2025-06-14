using LoftSecret.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoftSecret.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Verify(LoginViewModel model)
        {
            return View("Index", model);
        }

        // POST: /Login/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Verify", model);
            }
            else
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true
                };
                HttpContext.Response.Cookies.Append("loginToken", "abracadabra", cookieOptions);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

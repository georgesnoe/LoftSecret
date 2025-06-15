using Microsoft.AspNetCore.Mvc;
using LoftSecret.ViewModels;
using Microsoft.AspNetCore.Mvc.Routing;
using LoftSecret.Database;
using LoftSecret.Models;

namespace LoftSecret.Controllers
{
    public class SignupController : Controller
    {
        // GET: /Signup/Index or simply /Signup
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Verify(SignupViewModel model)
        {
            return View("Index", model);
        }

        // POST: /Signup/Signup
        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Verify", model);
            }
            else
            {
                await UtilisateursDb.AddUtilisateur(new Utilisateurs
                {
                    Email = model.Email,
                    MotDePasse = model.MotDePasse,
                    Nom = model.Nom,
                    Prenoms = model.Prenoms,
                    Telephone = model.Telephone,
                    RoleId = model.RoleId
                });
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

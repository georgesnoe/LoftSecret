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
                if (await UtilisateursDb.AddUtilisateur(new Utilisateurs
                {
                    Email = model.Email,
                    // Using hashed password
                    MotDePasse = Database.Database.HashPassword(model.MotDePasse),
                    Nom = model.Nom,
                    Prenoms = model.Prenoms,
                    Telephone = model.Telephone,
                    RoleId = model.RoleId
                }) == Database.Database.SQL_EMAIL_DUPLICATE)
                {
                    // If there is already an email, it returns 0
                    var emailExistsModel = model;
                    emailExistsModel.Email = Database.Database.SQL_EMAIL_DUPLICATE_STR;
                    return RedirectToAction("Verify", emailExistsModel);
                }
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

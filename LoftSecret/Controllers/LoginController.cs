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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Verify", model);
            }
            else
            {
                var utilisateur = await Database.UtilisateursDb.FindUtilisateurByEmail(model.Email);
                if (utilisateur == null)
                {
                    var emailNotExistsModel = model;
                    emailNotExistsModel.Email = Database.Database.SQL_EMAIL_NOT_EXISTS_STR;
                    return RedirectToAction("Verify", model);
                }
                else
                {
                    var password = model.MotDePasse;
                    if (Database.Database.HashPassword(password) == utilisateur.MotDePasse)
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(7),
                            HttpOnly = true
                        };
                        HttpContext.Response.Cookies.Append("loginToken", "abracadabra", cookieOptions);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var passwordErrorModel = model;
                        passwordErrorModel.MotDePasse = Database.Database.SQL_PASSWORD_ERROR_STR;
                        return RedirectToAction("Verify", model);
                    }
                }
            }
        }
    }
}

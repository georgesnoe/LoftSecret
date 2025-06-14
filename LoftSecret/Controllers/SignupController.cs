using Microsoft.AspNetCore.Mvc;
using LoftSecret.ViewModels;
using Microsoft.AspNetCore.Mvc.Routing;

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
        public IActionResult Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Verify", model);
            }
            return RedirectToAction("Index");
        }
    }
}

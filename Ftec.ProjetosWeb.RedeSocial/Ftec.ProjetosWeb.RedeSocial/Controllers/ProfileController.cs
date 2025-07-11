using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.RedeSocial.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult ProfileEdit()
        {
            return View();
        }
        public IActionResult AccountSettings()
        {
            return View();
        }
        public IActionResult PrivacySettings()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.RedeSocial.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult RecoverPassword()
        {
            return View();
        }
        public IActionResult ConfirmMail()
        {
            return View();
        }

    }
}

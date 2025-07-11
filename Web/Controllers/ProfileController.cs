using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Ftec.ProjetosWeb.RedeSocial.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            var usuarioJson = HttpContext.Session.GetString("Usuario");

            if (string.IsNullOrEmpty(usuarioJson))
            {
                // Se não estiver logado, redireciona pro login
                return RedirectToAction("SignIn", "Login");
            }

            // Desserializa o objeto salvo na sessão
            var usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioJson);

            // Envia o modelo completo pra view
            return View(usuario);
        }

        public IActionResult ProfileEdit()
        {
            return View();
        }
    }
}

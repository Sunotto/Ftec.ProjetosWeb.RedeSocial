using System.Diagnostics;
using Ftec.ProjetosWeb.RedeSocial.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.RedeSocial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TestarErro()
        {
            throw new Exception("Erro de teste lançado manualmente!");
        }
    }
}

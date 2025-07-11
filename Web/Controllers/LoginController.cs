using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.HTTPClient;
using Web.Models;

namespace Ftec.ProjetosWeb.RedeSocial.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly APIHttpClient _api;

        public LoginController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://usuario.neurosky.com.br/");
            _api = new APIHttpClient("http://usuario.neurosky.com.br/api/");
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(string username, string senha)
        {
            // 🔥 MOCK SIMPLES
            if (username == "usernametemporario" && senha == "123456")
            {
                var tokenMock = "mocked-token-123"; // simula um JWT

                var usuarioMock = new UsuarioViewModel
                {
                    NomeCompleto = "Luan Souza",
                    Email = "luande2010@gmail.com",
                    Username = "usernametemporario",
                    Telefone = "54992009460",
                    Genero = "Masculino",
                    Descricao = "Testando aqui",
                    Foto = "https://www.svgrepo.com/show/26473/avatar.svg",
                    DataNascimento = new DateTime(2001, 05, 06),
                };

                HttpContext.Session.SetString("Token", tokenMock);
                HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuarioMock));

                return RedirectToAction("Feed", "Feed");
            }

            ViewBag.Erro = "Usuário ou senha inválidos";
            return View("SignIn");
        }


        [HttpPost]
        public IActionResult Signup(SignUpViewModel model)
        {
            try
            {
                var novoUsuario = new
                {
                    Id = Guid.NewGuid(),
                    Username = model.Username,
                    Email = model.Email,
                    Senha = model.Senha,
                    NomeCompleto = model.NomeCompleto,
                    Telefone = model.Telefone,
                    Genero = model.Genero,
                    Descricao = model.Descricao,
                    Foto = model.Foto,
                    Token = "" // ou null, caso a API aceite gerar isso posteriormente
                };

                _api.Post<object>("Usuario", novoUsuario);

                TempData["Mensagem"] = "Usuário criado com sucesso!";
                return RedirectToAction("Feed", "Feed"); // ou qualquer outra página de destino
            }
            catch (Exception ex)
            {
                ViewBag.Erro = "Erro ao cadastrar: " + ex.Message;
                return View(model);
            }
        }

        public IActionResult SignIn()
        {
            return View();
        }

    }
}



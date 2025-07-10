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
            var login = new
            {
                Username = username,
                Senha = senha
            };

            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Usuario/autenticar", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<AutenticacaoResposta>(json);

                // Armazene o token em Cookie, Session etc
                HttpContext.Session.SetString("Token", dados.Token);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Usuário ou senha inválidos";
            return View("Login");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
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
        public IActionResult RecoverPassword()
        {
            return View();
        }
        public IActionResult AceitarMail()
        {
            return View();
        }

    }
}



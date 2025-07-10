using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.HTTPClient;
using Web.Models;
using static System.Net.WebRequestMethods;

namespace Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly HttpClient _http;
        private readonly APIHttpClient _api;

        public FeedController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _api = new APIHttpClient("http://feed.neurosky.com.br/api/"); // Ajuste se a porta for outra
        }

        public IActionResult Index()
        {
            try
            {
                var feed = _api.Get<List<FeedItemViewModel>>("Feed/geral");
                return View(feed);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = "Erro ao carregar o feed: " + ex.Message;
                return View(new List<FeedItemViewModel>());
            }
        }

        public async Task<IActionResult> Feed()
        {
            //try
            //{
            //    var feed = _api.Get<List<FeedItemViewModel>>("Feed/geral");
            //    return View(feed);
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Erro = "Erro ao carregar o feed: " + ex.Message;
            //    return View(new List<FeedItemViewModel>());
            //}

            var feedTask = _http.GetFromJsonAsync<List<FeedItemViewModel>>("http://feed.neurosky.com.br/api/Feed/geral");
            var comentarioTask = _http.GetFromJsonAsync<List<ComentarioViewModel>>("http://curtidas.neurosky.com.br/api/Comentarios/post/" + "461a4d14-68d2-47f2-9408-0e79b6e52d67");
            var curtidaTask = _http.GetFromJsonAsync<List<CurtidaViewModel>>("http://curtidas.neurosky.com.br/api/Curtidas/post/" + "461a4d14-68d2-47f2-9408-0e79b6e52d67");
            //var usuarioTask = _http.GetFromJsonAsync<List<UsuarioViewModel>>("http://usuario.neurosky.com.br/api/Usuario/luan218");

            await Task.WhenAll(feedTask, comentarioTask, curtidaTask/*, usuarioTask*/);

            var viewModel = new FeedCompletoViewModel
            {
                Feed = feedTask.Result,
                Comentarios = comentarioTask.Result,
                Curtidas = curtidaTask.Result,
                //Usuarios = usuarioTask.Result,

            };

            return View(viewModel);
        }

    }
}

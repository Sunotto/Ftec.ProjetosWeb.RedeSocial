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

        public async Task<IActionResult> Feed()
        {
            // --- Configuration for Mock Data ---
            bool useMockData = true; // True se for utilizar o mock
            // --- End Configuration ---

            // Initialize your ViewModel
            var viewModel = new FeedCompletoViewModel();

            if (useMockData)
            {
                var comentarioTask = _http.GetFromJsonAsync<List<ComentarioViewModel>>("http://curtidas.neurosky.com.br/api/Comentarios/post/" + "00000000-0000-0000-0000-000000000000");
                var curtidaTask = _http.GetFromJsonAsync<List<CurtidaViewModel>>("http://curtidas.neurosky.com.br/api/Curtidas/post/" + "00000000-0000-0000-0000-000000000000");

                await Task.WhenAll(comentarioTask, curtidaTask);

                viewModel.Comentarios = comentarioTask.Result;
                viewModel.Curtidas = curtidaTask.Result;
                viewModel.Feed = FeedDataMock.GetMockFeedItems();
                viewModel.Usuarios = UsuarioDataMock.GetMockUsuarios()
                                                    .Select(u => new UsuarioViewModel
                                                    {
                                                        Id = u.Id,
                                                        NomeCompleto = u.NomeCompleto,
                                                        Username = u.Username,
                                                        Foto = u.Foto,
                                                        // Map other relevant properties
                                                    }).ToList();
            }
            else
            {
                // If not using mock data, proceed with real API calls
                try
                {
                    // Start all API calls in parallel
                    var feedTask = _http.GetFromJsonAsync<List<FeedItemViewModel>>("http://feed.neurosky.com.br/api/Feed/geral");
                    var comentarioTask = _http.GetFromJsonAsync<List<ComentarioViewModel>>("http://curtidas.neurosky.com.br/api/Comentarios/post/" + "00000000-0000-0000-0000-000000000000");
                    var curtidaTask = _http.GetFromJsonAsync<List<CurtidaViewModel>>("http://curtidas.neurosky.com.br/api/Curtidas/post/" + "00000000-0000-0000-0000-000000000000");
                    var usuarioTask = _http.GetFromJsonAsync<List<UsuarioViewModel>>("http://usuario.neurosky.com.br/api/Usuario/GetAll"); // Assuming an endpoint for all users

                    // Wait for all tasks to complete
                    await Task.WhenAll(feedTask, comentarioTask, curtidaTask, usuarioTask);

                    // Assign the results to the ViewModel
                    viewModel.Feed = feedTask.Result;
                    viewModel.Comentarios = comentarioTask.Result;
                    viewModel.Curtidas = curtidaTask.Result;
                    viewModel.Usuarios = usuarioTask.Result;
                }
                catch (HttpRequestException ex) // Catch network or HTTP-specific errors
                {
                    ViewBag.Erro = $"Erro ao conectar à API: {ex.Message}";
                    // Optionally, return an empty ViewModel or redirect to an error page
                    return View(new FeedCompletoViewModel());
                }
                catch (Exception ex) // Catch any other unexpected errors
                {
                    ViewBag.Erro = $"Ocorreu um erro inesperado: {ex.Message}";
                    return View(new FeedCompletoViewModel());
                }
            }

            // Return the View with the populated ViewModel (either with mocked or real data)
            return View(viewModel);
        }

    }
}

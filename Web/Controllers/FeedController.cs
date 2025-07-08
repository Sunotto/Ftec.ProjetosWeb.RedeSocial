using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.HTTPClient;
using Web.Models;

namespace Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly APIHttpClient _api;

        public FeedController()
        {
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

        public IActionResult Feed()
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
    }
}

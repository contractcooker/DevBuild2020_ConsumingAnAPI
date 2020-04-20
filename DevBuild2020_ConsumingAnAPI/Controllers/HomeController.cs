using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevBuild2020_ConsumingAnAPI.Models;
using System.Net.Http;

namespace DevBuild2020_ConsumingAnAPI.Controllers
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

        public async Task<IActionResult> Draw()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com");
            var response = await client.GetAsync("api/deck/new/shuffle/?deck_count=1");
            var deck = await response.Content.ReadAsAsync<Deck>();
            //client.BaseAddress = new Uri("https://deckofcardsapi.com");
            string responseString = "api/deck/" + deck.Deck_id + "/draw/?count=5";
            response = await client.GetAsync(responseString);
            var hand = await response.Content.ReadAsAsync<Hand>();


            return View(hand);
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
    }
}

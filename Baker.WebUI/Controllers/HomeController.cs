using Baker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Baker.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Ürün sayısı
            var productRes = await client.GetAsync("https://localhost:7246/api/Product/CountProduct");
            ViewBag.ProductCount = productRes.IsSuccessStatusCode ? await productRes.Content.ReadAsStringAsync() : "0";

            // Şef sayısı
            var chefRes = await client.GetAsync("https://localhost:7246/api/Chef/CountChef");
            ViewBag.ChefCount = chefRes.IsSuccessStatusCode ? await chefRes.Content.ReadAsStringAsync() : "0";

            // Kategori sayısı
            var catRes = await client.GetAsync("https://localhost:7246/api/Category/CountCategory");
            ViewBag.CategoryCount = catRes.IsSuccessStatusCode ? await catRes.Content.ReadAsStringAsync() : "0";

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
    }
}
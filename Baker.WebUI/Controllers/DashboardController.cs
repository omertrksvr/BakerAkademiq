using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7246/api/Product/CountProduct");
            var jsonData1 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            return View();
        }
    }
}
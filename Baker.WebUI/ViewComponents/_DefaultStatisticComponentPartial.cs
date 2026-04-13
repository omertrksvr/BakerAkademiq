using Baker.WebUI.Dtos.Feature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Baker.WebUI.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7246/api/Product/CountProduct");
            var jsonData1 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;

            var responseMessage2 = await client.GetAsync("https://localhost:7246/api/Chef/CountChef");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ChefCount = jsonData2;
            return View();
        }
    }
}
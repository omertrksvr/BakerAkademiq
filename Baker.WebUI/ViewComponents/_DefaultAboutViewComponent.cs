using Baker.WebUI.Dtos.About;
using Baker.WebUI.Dtos.Chefs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Baker.WebUI.ViewComponents
{
    public class _DefaultAboutViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/About");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsondata);

                return View(values);
            }
            return View();
        }
    }
}
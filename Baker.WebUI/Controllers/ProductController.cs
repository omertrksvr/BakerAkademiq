using Baker.WebUI.Dtos.Chefs;
using Baker.WebUI.Dtos.Product;
using Baker.WebUI.Dtos.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Baker.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Product/with-category");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsondata);

                return View(values ?? new List<ProductWithCategoryDto>());
            }
            return View(new List<ProductWithCategoryDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Category");

            var jsonData = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Status: {response.StatusCode} | Data: {jsonData}");

            if (response.IsSuccessStatusCode)
            {
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                if (categories != null && categories.Any())
                {
                    ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                }
                else
                {
                    ViewBag.Categories = new SelectList(new List<ResultCategoryDto>(), "CategoryId", "CategoryName");
                }
            }
            else
            {
                ViewBag.Categories = new SelectList(new List<ResultCategoryDto>(), "CategoryId", "CategoryName");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Product", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            ViewBag.Error = $"Status: {response.StatusCode} | Hata: {errorContent}";

            var categoryResponse = await client.GetAsync("https://localhost:7246/api/Category");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"https://localhost:7246/api/Product/{id}");
            var jsonData = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            var categoryResponse = await client.GetAsync("https://localhost:7246/api/Category");
            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7246/api/Product", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            ViewBag.Error = $"Status: {response.StatusCode} | Hata: {errorContent}";

            var categoryResponse = await client.GetAsync("https://localhost:7246/api/Category");
            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", model.CategoryId);

            return View(model);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            await client.DeleteAsync($"https://localhost:7246/api/Product?id={id}");

            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByCategory()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(categories);
        }
    }
}
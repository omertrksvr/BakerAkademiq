using Baker.WebApi.Context;
using Baker.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BakerContext _context;

        public ProductController(BakerContext context)
        {
            _context = context;
        }
        [HttpGet("with-category")]
        public IActionResult GetProductWithCategory()
        {
            var products = _context.Products.Include(p => p.Category).Select(p => new ProductWithCategoryDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                İmageUrl = p.İmageUrl,
                CategoryName = p.Category != null ? p.Category.Name : null
            }).ToList();
            return Ok(products);
        }
        [HttpGet("CountProduct")]
        public IActionResult GetProductCount()
        {
            var totalProduct = _context.Products.Count();
            return Ok(totalProduct);
        }
    }
}
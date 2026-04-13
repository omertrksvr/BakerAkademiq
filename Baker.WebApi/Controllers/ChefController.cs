using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly BakerContext _context;

        public ChefController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var value = _context.Chefs.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var chef = _context.Chefs.Find(id);
            return Ok(chef);
        }

        [HttpPost]
        public IActionResult Create(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]

        public IActionResult Update(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }

        //product sayısı
        [HttpGet("CountChef")]
        public IActionResult GetChefCount()
        {
            var totalChef = _context.Chefs.Count();
            return Ok(totalChef);
        }
    }
}

using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {

        private readonly BakerContext _context;

        public AboutController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _context.Abouts.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound("Hakkımızda bilgisi bulunamadı.");
            }
            return Ok(about);
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("Hakkımızda ekleme işlemi başarıyla gerçekleşti.");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAbout(About about)
        {
            var existing = _context.Abouts.Find(about.aboutId);
            if (existing == null)
            {
                return NotFound("Hakkımızda bilgisi bulunamadı.");
            }
            existing.aboutId = about.aboutId;
            existing.Title = about.Title;
            existing.Description = about.Description;
          
            _context.SaveChanges();
            return Ok("Hakkımızda güncelleme işlemi başarıyla gerçekleşti.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound("Hakkımızda bilgisi bulunamadı.");
            }
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return Ok("Hakkımızda silme işlemi başarıyla gerçekleşti.");
        }
    }
}
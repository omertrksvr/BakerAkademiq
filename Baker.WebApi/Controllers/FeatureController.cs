using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly BakerContext _context;

        public FeatureController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult Create(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Kaydetme işlemi başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            return Ok();
        }
    }
}
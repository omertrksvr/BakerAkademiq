using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly BakerContext _context;
        public SubscribeController(BakerContext context) { _context = context; }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Subscribes.ToList());

        [HttpGet("CountSubscribe")]
        public IActionResult Count() => Ok(_context.Subscribes.Count());
    }
}
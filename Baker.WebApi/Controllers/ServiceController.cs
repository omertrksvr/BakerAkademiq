using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly BakerContext _context;
        public ServiceController(BakerContext context) { _context = context; }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Services.ToList());

        [HttpGet("CountService")]
        public IActionResult Count() => Ok(_context.Services.Count());
    }
}
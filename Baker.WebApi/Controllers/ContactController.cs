using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly BakerContext _context;
        public ContactController(BakerContext context) { _context = context; }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Contacts.ToList());
    }
}
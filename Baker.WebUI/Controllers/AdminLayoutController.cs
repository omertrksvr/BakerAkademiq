using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

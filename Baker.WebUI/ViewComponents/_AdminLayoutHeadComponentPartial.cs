using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
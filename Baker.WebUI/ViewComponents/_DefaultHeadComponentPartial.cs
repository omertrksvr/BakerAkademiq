using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
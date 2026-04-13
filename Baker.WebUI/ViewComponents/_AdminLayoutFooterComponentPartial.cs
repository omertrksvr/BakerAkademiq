using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
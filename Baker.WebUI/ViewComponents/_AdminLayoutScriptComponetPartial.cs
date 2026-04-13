using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.ViewComponents
{
    public class _AdminLayoutScriptComponetPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
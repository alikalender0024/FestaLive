using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

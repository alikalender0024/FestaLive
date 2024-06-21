using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

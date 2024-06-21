using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

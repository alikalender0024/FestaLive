using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

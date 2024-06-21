using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
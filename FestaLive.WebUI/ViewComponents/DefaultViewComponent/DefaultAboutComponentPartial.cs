using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

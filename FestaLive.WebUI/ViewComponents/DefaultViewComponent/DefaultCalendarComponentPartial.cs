using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultCalendarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

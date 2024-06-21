using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultPlanComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

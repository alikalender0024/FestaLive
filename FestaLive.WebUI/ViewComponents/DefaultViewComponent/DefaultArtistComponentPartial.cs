using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultArtistComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

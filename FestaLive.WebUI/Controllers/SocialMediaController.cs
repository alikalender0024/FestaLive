using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

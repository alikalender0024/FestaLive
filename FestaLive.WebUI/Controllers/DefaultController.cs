using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

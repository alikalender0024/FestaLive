using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

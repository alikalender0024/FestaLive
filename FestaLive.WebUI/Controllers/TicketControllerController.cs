using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class TicketControllerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

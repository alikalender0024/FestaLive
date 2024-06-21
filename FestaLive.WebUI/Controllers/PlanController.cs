using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

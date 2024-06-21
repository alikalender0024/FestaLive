using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class AboutController(IAboutService aboutService) : Controller
    {
        private readonly IAboutService _aboutService = aboutService;

        public IActionResult AboutList()
        {
            var result = _aboutService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _aboutService.Add(about);
            return RedirectToAction("AboutList");
        }
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.Delete(id);
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var entity = _aboutService.GetById(id).Data;
            return View(entity);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.Update(about);
            return RedirectToAction("AboutList");
        }
    }
}

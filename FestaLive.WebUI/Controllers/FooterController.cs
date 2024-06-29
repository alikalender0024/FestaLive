using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class FooterController : Controller
    {
        private readonly IFooterService _footerService;

        public FooterController(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public IActionResult FooterList()
        {
            var footers = _footerService.GetAll().Data;
            return View(footers);
        }

        [HttpGet]
        public IActionResult CreateFooter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFooter(Footer footer)
        {
            if (ModelState.IsValid)
            {
                _footerService.Add(footer);
                return RedirectToAction("FooterList");
            }

            return View(footer);
        }
        public IActionResult DeleteFooter(int id)
        {
            _footerService.Delete(id);
            return RedirectToAction("FooterList");
        }
        [HttpGet]
        public IActionResult UpdateFooter(int id)
        {
            var footer = _footerService.GetById(id).Data;
            if (footer == null)
            {
                return NotFound();
            }

            return View(footer);
        }

        [HttpPost]
        public IActionResult UpdateFooter(Footer footer)
        {
            if (ModelState.IsValid)
            {
                _footerService.Update(footer);
                return RedirectToAction("FooterList");
            }

            return View(footer);
        }
    }
}

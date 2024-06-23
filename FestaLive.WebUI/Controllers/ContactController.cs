using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using FestaLive.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class ContactController(IContactFormService contactFormService) : Controller
    {
        private readonly IContactFormService _contactFormService = contactFormService;

        [HttpPost]
        public IActionResult Submit(ContactForm contactForm) 
        {
            _contactFormService.Add(contactForm);
            return RedirectToAction("Index", "Default");
        }
    }
}

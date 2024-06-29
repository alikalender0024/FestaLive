using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class SocialMediaController(ISocialMediaService socialMediaService) : Controller
    {
        private readonly ISocialMediaService _socialMediaService = socialMediaService;

        public IActionResult SocialMediaList()
        {
            var result = _socialMediaService.GetAll().Data;
            return View(result);
        }
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.Add(socialMedia);
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = _socialMediaService.GetById(id).Data;
            return View(socialMedia);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.Update(socialMedia);
            return RedirectToAction("SocialMediaList");
        }

        [HttpPost]
        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaService.Delete(id);
            return RedirectToAction("SocialMediaList");
        }
    }
}
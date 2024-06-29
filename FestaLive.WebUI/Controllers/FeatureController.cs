using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class FeatureController(IFeatureService featureService) : Controller
    {
        private readonly IFeatureService _featureService = featureService;

        public IActionResult FeatureList()
        {
            var result = _featureService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(Feature feature)
        {
            _featureService.Add(feature);
            return RedirectToAction("FeatureList");
        }
        public IActionResult DeleteFeature(int id)
        {
            _featureService.Delete(id);
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var entity = _featureService.GetById(id).Data;
            return View(entity);
        }

        [HttpPost]
        public IActionResult UpdateFeature(Feature feature)
        {
            _featureService.Update(feature);
            return RedirectToAction("FeatureList");
        }
    }
}

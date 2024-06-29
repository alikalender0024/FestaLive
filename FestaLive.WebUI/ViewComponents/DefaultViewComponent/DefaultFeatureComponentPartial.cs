using FestaLive.Business.Abstract;
using FestaLive.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultFeatureComponentPartial(IFeatureService featureService,ISocialMediaService socialMediaService) : ViewComponent
    {
        private readonly IFeatureService _featureService = featureService;
        private readonly ISocialMediaService _socialMediaService = socialMediaService;

        public IViewComponentResult Invoke()
        {
            var result = _featureService.GetAll().Data;
            var socialMedias = _socialMediaService.GetAll().Data;

            var viewModel = new FeatureAndSocialMediaViewModel
            {
                Features = result,
                SocialMedias = socialMedias
            };

            return View(viewModel);
        }
    }
}

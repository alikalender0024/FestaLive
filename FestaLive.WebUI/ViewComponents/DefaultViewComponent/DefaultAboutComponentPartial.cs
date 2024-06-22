using FestaLive.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultAboutComponentPartial(IAboutService aboutService) : ViewComponent
    {
        private readonly IAboutService _aboutService = aboutService;

        public IViewComponentResult Invoke()
        {
            var result = _aboutService.GetAll().Data.FirstOrDefault();
            return View(result);
        }
    }
}

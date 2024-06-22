using FestaLive.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultFooterComponentPartial(IFooterService footerService) : ViewComponent
    {
        private readonly IFooterService _footerService = footerService;

        public IViewComponentResult Invoke()
        {
            var result = _footerService.GetAll().Data;
            return View(result);
        }
    }
}
using FestaLive.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultCalendarComponentPartial(IEventService eventService): ViewComponent
    {

        private readonly IEventService _eventService = eventService;

        public IViewComponentResult Invoke()
        {
            var result = _eventService.GetAll().Data;
            return View(result);
        }
    }
}

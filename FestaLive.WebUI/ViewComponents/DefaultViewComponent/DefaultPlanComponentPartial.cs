using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.ViewComponents.DefaultViewComponent
{
    public class DefaultPlanComponentPartial(IPlanService planService) : ViewComponent
    {
        private readonly IPlanService _planService = planService;

        public IViewComponentResult Invoke()
        {
            var plans = _planService.GetAll().Data;

            foreach (var plan in plans)
            {
                if (plan.Features != null)
                {
                    plan.Features = LoadFeaturesFromDB(string.Join(",", plan.Features));
                }
            }

            ViewBag.Plans = plans;
            return View(plans);
        }

        public List<string> LoadFeaturesFromDB(string featuresString)
        {
            var features = new List<string>(featuresString.Split(','));
            return features;
        }
    }
}

using FestaLive.Business.Abstract;
using FestaLive.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FestaLive.WebUI.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        public IActionResult PlanList()
        {
            var result = _planService.GetAll().Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult CreatePlan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlan(Plan plan)
        {
            if (ModelState.IsValid)
            {
                _planService.Add(plan);
                return RedirectToAction("PlanList");
            }
            return View(plan);
        }

        public IActionResult DeletePlan(int id)
        {
            _planService.Delete(id);
            return RedirectToAction("PlanList");
        }

        [HttpGet]
        public IActionResult UpdatePlan(int id)
        {
            var plan = _planService.GetById(id).Data;
            return View(plan);
        }

        [HttpPost]
        public IActionResult UpdatePlan(Plan plan, string features)
        {
            // Split incoming features by newline and trim whitespace
            string[] newFeaturesArray = features.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(f => f.Trim())
                                                .ToArray();

            // Serialize array to JSON
            string newFeaturesJson = JsonConvert.SerializeObject(newFeaturesArray);

            // Save changes to database (assuming you have a method for saving changes)
            _planService.Update(plan);

            // Redirect to the plan list page after updating
            return RedirectToAction("PlanList");
        }
    }
}

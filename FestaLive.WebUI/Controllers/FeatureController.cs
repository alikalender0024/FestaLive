﻿using Microsoft.AspNetCore.Mvc;

namespace FestaLive.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
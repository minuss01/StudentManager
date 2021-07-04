﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB.Models;

namespace WEB.Controllers
{
    public class DashboardController : Controller
    {

        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

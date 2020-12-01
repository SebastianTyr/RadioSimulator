using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadioConsole.Web.Models.Enums;
using RadioConsole.Web.Models;

namespace RadioConsole.Web.Controllers
{
    public class RadioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RadioModel model)
        {
            return View("RegisterConfirmation");
        }

        [HttpGet]
        public IActionResult RegisterConfirmation(int radioId)
        {
            return View(radioId);
        }
    }
}

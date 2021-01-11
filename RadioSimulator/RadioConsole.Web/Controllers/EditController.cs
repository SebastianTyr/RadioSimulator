﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RadioConsole.Web.Controllers
{
    public class EditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditRadio()
        {
            return View("EditRadio");
        }
    }
}

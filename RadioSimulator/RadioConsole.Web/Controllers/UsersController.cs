using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RadioConsole.Web.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Users()
        {
            return View();
        }
    }
}

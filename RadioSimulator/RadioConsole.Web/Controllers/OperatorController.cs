using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadioConsole.Web.Database;
using RadioConsole.Web.Models.Enums;

namespace RadioConsole.Web.Controllers
{
    public class OperatorController : Controller
    {
        private readonly RadioDBContext _dbContext;

        public OperatorController(RadioDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Map()
        {
            ViewBag.Police = _dbContext.Radios.Where(u => u.Unit == Unit.Police).Take(1);
            ViewBag.Emergency = _dbContext.Radios.Where(u => u.Unit == Unit.Emergency).Take(1);
            ViewBag.FireBrigade = _dbContext.Radios.Where(u => u.Unit == Unit.FireBrigade).Take(1);
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadioConsole.Web.Database;
using RadioConsole.Web.Entities;
using RadioConsole.Web.Models;

namespace RadioConsole.Web.Controllers
{
    [Authorize]
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
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult NewIncident()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> NewIncident(IncidentModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            var incident = new IncidentEntity
            {
                Description = model.Description,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Group = model.Group,
            };

            _dbContext.Add(incident);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("IncidentList");
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult IncidentList()
        {
            ViewBag.Items = _dbContext.Incidents;
            return View();
        }
    }
}

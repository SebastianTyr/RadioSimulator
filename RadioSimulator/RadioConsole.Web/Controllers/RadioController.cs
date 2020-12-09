using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadioConsole.Web.Models.Enums;
using RadioConsole.Web.Models;
using RadioConsole.Web.Models.Validators;
using RadioConsole.Web.Database;
using RadioConsole.Web.Entities;

namespace RadioConsole.Web.Controllers
{
    public class RadioController : Controller
    {
        private readonly RadioDBContext _dbContext;
        public RadioController(RadioDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Items = _dbContext.Radios;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RadioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var radioEntity = new RadioEntity
            {
                Name = model.Name,
                Type = model.Type,
                SerialNumber = model.SerialNumber,
                SignalStrength = model.SignalStrength,
                BatteryLevel = model.BatteryLevel,
                Mode = model.Mode
            };

            _dbContext.Add(radioEntity);
            await _dbContext.SaveChangesAsync();

            return View("RegisterConfirmation");
        }

        [HttpGet]
        public IActionResult RegisterConfirmation(int radioId)
        {
            return View(radioId);
        }
    }
}

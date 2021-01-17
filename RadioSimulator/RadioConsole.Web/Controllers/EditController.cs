using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadioConsole.Web.Database;
using RadioConsole.Web.Entities;
using RadioConsole.Web.Models;

namespace RadioConsole.Web.Controllers
{
    public class EditController : Controller
    {
        private readonly RadioDBContext _dbContext;

        public EditController(RadioDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditRadio(string id)
        {
            int radioId = Convert.ToInt32(id);
            var rawData = _dbContext.Radios.Find(radioId);

            return View(rawData);
        }

        [HttpPost]
        public async Task<IActionResult> EditRadio(RadioModel model)
        {
            var rawData = _dbContext.Radios.Find(model.Id);
            if (rawData != null)
            {
                rawData.Name = model.Name;
                rawData.Type = model.Type;
                rawData.SerialNumber = model.SerialNumber;
                rawData.SignalStrength = model.SignalStrength;
                rawData.BatteryLevel = model.BatteryLevel;
                rawData.Mode = model.Mode;
                rawData.Unit = model.Unit;
            }

            await _dbContext.SaveChangesAsync();

            return View("EditRadio");
        }
    }
}

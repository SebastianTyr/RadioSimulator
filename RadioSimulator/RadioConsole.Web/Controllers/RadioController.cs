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
using MimeKit;
using MailKit.Net.Smtp;

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
                Mode = model.Mode,
                Unit = model.Unit
            };

            _dbContext.Add(radioEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("RegisterConfirmation");
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

            return RedirectToAction("RegisterConfirmation");
        }

        public async Task<IActionResult> Delete(RadioEntity radio)
        {
            _dbContext.Delete(radio);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("RegisterConfirmation");
        }

        [HttpGet]
        public IActionResult RegisterConfirmation()
        {
            ViewBag.Items = _dbContext.Radios;
            return View();
        }
    }
}

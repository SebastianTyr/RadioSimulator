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
        public IActionResult EditRadio()
        {
            ViewBag.Items = _dbContext.Radios;
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> EditRadio(RadioEntity radioEntity)
        {
            _dbContext.Update(radioEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("EditRadio");
        }
    }
}

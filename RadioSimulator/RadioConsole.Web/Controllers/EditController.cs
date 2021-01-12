using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadioConsole.Web.Database;
using RadioConsole.Web.Entities;

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
            return View("EditRadio");
        }

        [HttpPost]
        public async Task<IActionResult> EditRadio(int id, [Bind("Id, Name, Type, SerialNumber, SignalStrencht, BatteryLevel, Mode, Unit")] RadioEntity radioEntity)
        {
            if(id != radioEntity.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(radioEntity);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(EditRadio));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                    Console.WriteLine(ex.Message);
                }
            }
            return View(radioEntity);
        }
    }
}

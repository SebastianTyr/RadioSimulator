using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RadioConsole.Web.Models;
using RadioConsole.Web.Database;
using RadioConsole.Web.Entities;

namespace RadioConsole.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly RadioDBContext _dbContext;

        public LoginController(RadioDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public IActionResult OperatorLogin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DispatcherLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DispatcherLogin([Bind] UsersModel model)
        {
            var user = _dbContext.Users.Where(u => u.Username == model.Username && u.Password == model.Password).SingleOrDefault();

            if (user != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("Username", user.Username),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                 };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Register", "Radio");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult OperatorLogin([Bind] UsersModel model)
        {
            var user = _dbContext.Users.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();

            if (user != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("Username", user.Username),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Map", "Operator");
            }

            return View(user);
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction("Users", "Users");
        //}

        //public async Task SingOut(string redirectUri)
        //{
        //    await HttpContext.SignOutAsync("Cookies");
        //    var prop = new AuthenticationProperties()
        //    {
        //        RedirectUri = redirectUri
        //    };
        //    await HttpContext.SignOutAsync("Users", prop);
        //}
    }
}

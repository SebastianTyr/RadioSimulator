using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RadioConsole.Web.Models;

namespace RadioConsole.Web.Controllers
{
    public class LoginController : Controller
    {
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
            var user = new UsersModel().GetUsers().Where(u => u.Username == model.Username).SingleOrDefault();

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
            var user = new UsersModel().GetUsers().Where(x => x.Username == model.Username).SingleOrDefault();

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
    }
}

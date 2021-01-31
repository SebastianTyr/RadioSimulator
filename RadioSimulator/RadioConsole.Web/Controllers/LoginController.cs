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
        public IActionResult DispatcherLogin([Bind] UsersModel user)
        {
            var users = new UsersModel();
            var allUsers = users.GetUsers().FirstOrDefault();
            if (users.GetUsers().Any(u => u.Username == user.Username))
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, user.Username)
                 };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Register", "Radio");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult OperatorLogin([Bind] UsersModel user)
        {
            var users = new UsersModel();
            var allUsers = users.GetUsers().FirstOrDefault();
            if (users.GetUsers().Any(u => u.Username == user.Username))
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, user.Username)
                 };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Map", "Operator");
            }

            return View(user);
        }
    }
}

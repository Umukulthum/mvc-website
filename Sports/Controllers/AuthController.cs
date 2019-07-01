using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sports.Models;

namespace Sports.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly string Username = "Admin";
        private readonly string Password = "admin";
        // GET: /<controller>/
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            TempData["Failed"] = null;
            if (!ModelState.IsValid)
            {
                TempData["Failed"] = "failed";
                model.Password = string.Empty;
                return View(model);
            }
            if (!Username.Equals(model.Username, StringComparison.InvariantCultureIgnoreCase) ||
                !Password.Equals(model.Password))
            {
                TempData["Failed"] = "failed";
                ModelState.AddModelError("Error", "Username or Password is invalid");
                return View(model);
            }
            //return Redirect("~/Protected/Index");
            return RedirectToAction("Index", "Home", new { area = "Admins" });
            //return RedirectToAction("Index", "Protected");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginModel = new LoginViewModel();
            return View(loginModel);
        }
    }
}
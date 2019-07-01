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
        private readonly string CusUsername = "Cus";
        private readonly string CusPassword = "cus";

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
                 AdminLogin(model);
                

            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "Admins" });
            }
            if (!CusUsername.Equals(model.Username, StringComparison.InvariantCultureIgnoreCase) ||
                   !CusPassword.Equals(model.Password))
            {
                Cuslogin(model);
                
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "CustomerArea" });
            }
            return View(model);
         
        }
        [HttpGet]
        public IActionResult Login()
        {
            var loginModel = new LoginViewModel();
            return View(loginModel);
        }

        public IActionResult Cuslogin(LoginViewModel model)
        { 
                TempData["Failed"] = "failed";
                ModelState.AddModelError("Error", "Username or Password is invalid");
                return View(model);    
        }

        public IActionResult AdminLogin(LoginViewModel model)
            {
               
                    TempData["Failed"] = "failed";
                    ModelState.AddModelError("Error", "Username or Password is invalid");
                    return View(model);
                //return Redirect("~/Protected/Index");   
                //return RedirectToAction("Index", "Protected");
            }
  
    }
}
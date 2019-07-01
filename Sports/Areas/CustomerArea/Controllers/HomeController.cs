using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sports.Areas.CustomerArea.Controllers
{
    [Area("CustomerArea")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
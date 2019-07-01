using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sports.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ProtectedController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }

}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project_basic_Authentication.Models;
using System.Diagnostics;

namespace project_basic_Authentication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Superviser,employee")]
        public IActionResult Sales()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Superviser")]

        public IActionResult Shopping()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Clients()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
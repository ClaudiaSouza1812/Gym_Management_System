using Microsoft.AspNetCore.Mvc;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using System.Diagnostics;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Controllers
{
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

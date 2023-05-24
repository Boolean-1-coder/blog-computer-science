using BlogComputerScience.Models;
using BlogComputerScience.Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogComputerScience.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (BlogContext db = new())
            {
                List<Article> articoli = db.Articles.ToList();
                return View(articoli);
            }
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View("Privacy1");
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            UserProfile profiloDiBryan = new UserProfile("Bryan", "Lucchetta", 26);

            return View(profiloDiBryan);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
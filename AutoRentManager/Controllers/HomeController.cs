using AutoRentManager.Data;
using AutoRentManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoRentManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public HomeController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public IActionResult Index()
        {
            var cars = dbContext.Cars.ToList();
            return View(cars);
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

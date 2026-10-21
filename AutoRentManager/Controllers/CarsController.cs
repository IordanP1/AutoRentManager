using AutoRentManager.Data;
using AutoRentManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentManager.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CarsController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public IActionResult Index()
        {
            var cars  = dbContext.Cars.ToList();
            return View(cars);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
           
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            dbContext.Cars.Add(car);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

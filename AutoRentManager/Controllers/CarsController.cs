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
        [HttpGet]
        public IActionResult Details(int id)
        {
            var car = dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }   

        [HttpPost]
        public IActionResult Edit(int id, Car car)
        {
            if (id!=car.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            dbContext.Cars.Update(car);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        public IActionResult DeleteConformation(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

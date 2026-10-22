using AutoRentManager.Data;
using AutoRentManager.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

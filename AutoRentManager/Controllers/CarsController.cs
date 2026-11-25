using AutoRentManager.Data.Data;
using AutoRentManager.Data.Models;
using AutoRentManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentManager.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }
        public IActionResult Index()
        {
            var cars  = carService.GetAll();
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
            carService.Add(car);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var car = carService.GetById(id);
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
            var car = carService.GetById(id);
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
            carService.Update(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var car = carService.GetById(id);
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
           bool isDelleted = carService.Delete(id);
            if (!isDelleted)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace AutoRentManager.Controllers
{
    using AutoRentManager.Services.Interfaces;
    using AutoRentManager.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        [HttpGet]
        public IActionResult Create(int carId)
        {
            var car = reservationService.GetCarById(carId);
            if (car==null)
            {
                return NotFound();
            }
            ViewBag.Car = car;
            return View();
        }
        [HttpPost]
        public IActionResult Create(int carId,string FirstName,string LastName,string Email,string phoneNumber,DateTime StartDate, DateTime EndDate)
        {
            var car = reservationService.GetCarById(carId);
            if (car==null)
            {
                return NotFound();
            }

            ViewBag.Car = car;

            var result = reservationService.CreateReservation(
                carId,
                FirstName,
                LastName,
                Email,
                phoneNumber,
                StartDate,
                EndDate);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var reservationInfo = reservationService.GetAll()
                .Select(r => new ReservationViewModel
                {
                    Id = r.Id,
                    CarInfo = r.Car.Brand + " " + r.Car.Model,
                    CustomerName = r.Customer.FirstName + " " + r.Customer.LastName,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    TotalPrice = r.TotalPrice,
                    Status = r.Status.ToString()
                })
                .ToList();
            return View(reservationInfo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Confirm(int id) 
        {
           
            if (!reservationService.Confirm(id))
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Cancel(int id)
        {
            if (!reservationService.Cancel(id))
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}

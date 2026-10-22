using AutoRentManager.Data;
using AutoRentManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentManager.Controllers
{
    using AutoRentManager.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ReservationsController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public IActionResult Create(int carId)
        {
            var car = dbContext.Cars.Find(carId);
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
            var car = dbContext.Cars.Find(carId);
            if (car==null)
            {
                return NotFound();
            }

            ViewBag.Car = car;

            if (string.IsNullOrWhiteSpace(FirstName)||string.IsNullOrWhiteSpace(LastName)||string.IsNullOrWhiteSpace(Email)||string.IsNullOrWhiteSpace(phoneNumber))
            {
                ViewBag.ErrorMessage = "All fields are required!";
                return View();
            }
            if (phoneNumber.Length!=10||!phoneNumber.All(char.IsDigit))
            {
                ViewBag.ErrorMessage = "Phone number must containt exactly 10 digits!";
                return View();
            }

            if (EndDate.Date<=StartDate.Date)
            {
                ViewBag.ErrorMessage = "End date must be after the sratr date!";
                return View();
            }
            var conflictingReservation = dbContext.Reservations
                .FirstOrDefault(r =>r.CarId == carId &&
                r.Status == AutoRentManager.Enums.ReservationStatus.ReservationStatuses.Confirmed &&
                StartDate.Date < r.EndDate.Date &&
                EndDate.Date > r.StartDate.Date);

            if (conflictingReservation != null)
            {
                ViewBag.ErrorMessage =
                    "This car is already reserved for the selected dates.";

                return View();
            }

            var customer = dbContext.Customers.FirstOrDefault(c => c.Email ==Email);

            if (customer==null)
            {
                customer = new Customer
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = phoneNumber
                };
                dbContext.Customers.Add(customer);

            }
            dbContext.SaveChanges();

            int rentDays = (EndDate.Date - StartDate.Date).Days;
            decimal totalPrice = rentDays * car.PricePerDay;

            var reservation = new Reservation
            {
                CarId = carId,
                CustomerId = customer.Id,
                StartDate = StartDate,
                EndDate = EndDate,
                TotalPrice = totalPrice
            };
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var reservationInfo = dbContext.Reservations
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
            var reservation = dbContext.Reservations.Find(id);
            if (reservation==null)
            {
                return NotFound();
            }
            reservation.Status = Enums.ReservationStatus.ReservationStatuses.Confirmed;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Cancel(int id)
        {
            var reservation = dbContext.Reservations.Find(id);
            if (reservation==null)
            {
                return NotFound();
            }
            reservation.Status = Enums.ReservationStatus.ReservationStatuses.Cancelled;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

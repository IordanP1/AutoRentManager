using AutoRentManager.Data.Data;
using AutoRentManager.Data.Models;
using AutoRentManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoRentManager.Services.Core
{
    public class ReservationService : IReservationService
    {
        public readonly ApplicationDbContext dbContext;
        public ReservationService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public bool Cancel(int id)
        {
            var reservation = dbContext.Reservations.Find(id);
            if (reservation==null)
            {
                return false;
            }
            reservation.Status = Data.Enums.ReservationStatus.ReservationStatuses.Cancelled;
            dbContext.SaveChanges();

            return true;
        }

        public bool Confirm(int id)
        {
            var reservation = dbContext.Reservations.Find(id);
            if (reservation == null)
            {
                return false;
            }
            reservation.Status = Data.Enums.ReservationStatus.ReservationStatuses.Confirmed;
             dbContext.SaveChanges();

            return true;
        }

        public (bool Success, string? ErrorMessage) CreateReservation(int carId, string firstName, string lastName, string email, string phoneNumber, DateTime startDate, DateTime endDate)
        {
            var car = dbContext.Cars.Find(carId);
            if (car == null)
            {
                return (false, "Car not found!");
            }
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                return (false, "All fields are required!");
            }
            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                return (false, "Phone number must contain exactly 10 digits!");
            }
            if (endDate.Date <= startDate.Date)
            {
                return (false, "End date must be after the start date!");
            }
            var conflictingReservation = dbContext.Reservations
                .FirstOrDefault(r => r.CarId == carId &&
                r.Status == Data.Enums.ReservationStatus.ReservationStatuses.Confirmed &&
                startDate.Date < r.EndDate.Date &&
                endDate.Date > r.StartDate.Date);
            if (conflictingReservation != null)
            {
                return (false, "The selected dates conflict with an existing reservation.");
            }

            var customer = dbContext.Customers
                .FirstOrDefault(c => c.Email == email);

            if (customer == null)
            {
                customer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };
            }

            var totalDays = (endDate.Date - startDate.Date).Days;
            var totalPrice = totalDays * car.PricePerDay;


            var reservation = new Reservation
                {
                    CarId = carId,
                    Customer = customer,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalPrice = totalPrice,
                    Status = Data.Enums.ReservationStatus.ReservationStatuses.Pending
                };
                dbContext.Reservations.Add(reservation);
                dbContext.SaveChanges();

                return (true, null);
            }
        

        public List<Reservation> GetAll()
        {
            return dbContext.Reservations
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .ToList();
            
        }

        public Car? GetCarById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

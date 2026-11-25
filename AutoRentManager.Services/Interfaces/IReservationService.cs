using AutoRentManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRentManager.Services.Interfaces
{
    public interface IReservationService
    {
        Car? GetCarById(int id);

        (bool Success, string? ErrorMessage) CreateReservation(
            int carId,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            DateTime startDate,
            DateTime endDate);

        List<Reservation> GetAll();
        

        bool Confirm(int id);

        bool Cancel(int id);
    }
}

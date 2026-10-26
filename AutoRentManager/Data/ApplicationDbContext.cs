using AutoRentManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static AutoRentManager.Enums.CarCategoryType;
using static AutoRentManager.Enums.FuelType;
using static AutoRentManager.Enums.TransmissionType;

namespace AutoRentManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 2,
                    Brand = "BMW",
                    Model = "760L",
                    Year = 2024,
                    Category = CarCategoryTypes.Luxury,
                    Description = "fast",
                    ImageUrl = "/images/cars/bmw760l.jpg",
                    RegistrationNumber = "CB0000AA",
                    PricePerDay = 299.00m,
                    FuelType = FuelTypes.Petrol,
                    TransmissionType = TransmissionTypes.Automatic
                },
                new Car
                {
                    Id = 3,
                    Brand = "bmw",
                    Model = "340i",
                    Year = 2025,
                    Category = CarCategoryTypes.Sport,
                    Description = "fast",
                    ImageUrl = "/images/cars/bmw340i.jpg",
                    RegistrationNumber = "CB0000AA",
                    PricePerDay = 190.00m,
                    FuelType = FuelTypes.Petrol,
                    TransmissionType = TransmissionTypes.Automatic
                },
                new Car
                {
                    Id = 4,
                    Brand = "Bmw",
                    Model = "X5m",
                    Year = 2025,
                    Category = CarCategoryTypes.SUV,
                    Description = "Suv",
                    ImageUrl = "/images/cars/bmwX5m.jpg",
                    RegistrationNumber = "CB0030AA",
                    PricePerDay = 340.00m,
                    FuelType = FuelTypes.Petrol,
                    TransmissionType = TransmissionTypes.Automatic
                },
                new Car
                {
                    Id = 5,
                    Brand = "Van",
                    Model = "Exotic",
                    Year = 2025,
                    Category = CarCategoryTypes.Van,
                    Description = "Van you can drive around with all of your friends",
                    ImageUrl = "/images/cars/van.jpg",
                    RegistrationNumber = "CB0040AA",
                    PricePerDay = 189.00m,
                    FuelType = FuelTypes.Hybrid,
                    TransmissionType = TransmissionTypes.Automatic
                },
                new Car
                {
                    Id = 6,
                    Brand = "BMW",
                    Model = "M5comp",
                    Year = 2022,
                    Category = CarCategoryTypes.Sport,
                    Description = "Best 5-series",
                    ImageUrl = "/images/cars/bmwM5Comp.jpg",
                    RegistrationNumber = "CB1133AA",
                    PricePerDay = 450.00m,
                    FuelType = FuelTypes.Petrol,
                    TransmissionType = TransmissionTypes.Automatic
                },
                new Car
                {
                    Id = 8,
                    Brand = "BMW",
                    Model = "M4",
                    Year = 2025,
                    Category = CarCategoryTypes.Sport,
                    Description = "Track beast",
                    ImageUrl = "/images/cars/bmwM4.jpg",
                    RegistrationNumber = "CB0000AA",
                    PricePerDay = 359.00m,
                    FuelType = FuelTypes.Petrol,
                    TransmissionType = TransmissionTypes.Automatic
                }
            );

        }
    }
}

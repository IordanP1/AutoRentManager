using AutoRentManager.Data.Data;
using AutoRentManager.Data.Models;
using AutoRentManager.Services.Interfaces;

namespace AutoRentManager.Services.Core
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext dbContext;
        public CarService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Car car)
        {
            dbContext.Cars.Add(car);
            dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var car = GetById(id);
            if (car == null)
            {
                return false;
            }
            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();
            return true;

        }

        public List<Car> GetAll()
        {
            return dbContext.Cars.ToList();
        }

        public Car? GetById(int id)
        {
            return dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }
        

        public void Update(Car car)
        {
            dbContext.Cars.Update(car);
            dbContext.SaveChanges();
        }
    }
}

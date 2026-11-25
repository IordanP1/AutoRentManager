using AutoRentManager.Data.Models;

namespace AutoRentManager.Services.Interfaces
{
    public interface ICarService
    {
        List<Car> GetAll();

        Car? GetById(int id);

        void Add(Car car);

        void Update(Car car);

        bool Delete(int id);
    }
}

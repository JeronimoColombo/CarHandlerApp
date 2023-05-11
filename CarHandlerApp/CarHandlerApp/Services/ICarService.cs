using CarHandlerApp.Models;

namespace CarHandlerApp.Services
{
    public interface ICarService
    {
        List<Car> GetCars();
        bool IsPriceCorrect(int carId, double price);
    }
}

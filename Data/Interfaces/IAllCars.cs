using Awarenessmvc.Data.Models;
using System.Collections.Generic;

namespace Awarenessmvc.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavCars { get; }
        Car GetObjectCar(int carID);
    }
}

using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Awarenessmvc.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDbContent;
        public CarRepository(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);
        public IEnumerable<Car> GetFavCars => appDbContent.Car.Where(x => x.IsFavourite).Include(c => c.Category);
        public Car GetObjectCar(int carID) => appDbContent.Car.FirstOrDefault(x => x.Id == carID);
    }
}
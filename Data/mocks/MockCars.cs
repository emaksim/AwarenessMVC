using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Awarenessmvc.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> Cars =>
            new List<Car>
            {
                new Car
                {
                    Name = "Tesla",
                    ShortDesc = "aaaaa",
                    LongDesc = "sadasdasdasdasdsada",
                    Img = "/img/net.png",
                    Price = 4500,
                    IsFavourite = true,
                    Available = true,
                    Category = _carsCategory.AllCategories.First()

                },
                new Car
                {
                    Name = "Ford Fiesta",
                    ShortDesc = "aaaaaa",
                    LongDesc = "asdasdasdadasd",
                    Img ="/img/ios.png",
                    Price = 4500,
                    IsFavourite = true,
                    Available = true,
                    Category = _carsCategory.AllCategories.Last()
                }
            };

        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
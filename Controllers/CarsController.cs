using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using Awarenessmvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Awarenessmvc.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategory;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory)
        {
            _allCars = iAllCars;
            _allCategory = iCarsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(x => x.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(x => x.Category.CategoryName.Equals("Электромобили")).OrderBy(x => x.Id);
                    currentCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(x => x.Category.CategoryName.Equals("Классические")).OrderBy(x => x.Id);
                    currentCategory = "Классические";
                }

            }
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                CurrentCategory = currentCategory
            };

            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }
    }
}
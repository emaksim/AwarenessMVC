using Awarenessmvc.Data.Models;
using System.Collections.Generic;

namespace Awarenessmvc.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrentCategory { get; set; }
    }
}

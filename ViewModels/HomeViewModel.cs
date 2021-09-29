using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Awarenessmvc.Data.Models;

namespace Awarenessmvc.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavoriteCars { get; set; }
    }
}

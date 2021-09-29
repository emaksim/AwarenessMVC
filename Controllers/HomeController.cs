using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using Awarenessmvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Awarenessmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public HomeController(IAllCars carRepository)
        {
            _carRep = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavoriteCars = _carRep.GetFavCars
            };
            return View(homeCars);
    }
}
}

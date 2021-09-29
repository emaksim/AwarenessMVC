using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Awarenessmvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders orders, ShopCart shopCart)
        {
            this.allOrders = orders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopCartItems = shopCart.GetShopItems();
            if (!shopCart.ListShopCartItems.Any())
                ModelState.AddModelError("", "должны быть товары");

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
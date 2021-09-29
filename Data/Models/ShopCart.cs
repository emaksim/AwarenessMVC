using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Awarenessmvc.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDbContent;

        public ShopCart(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            
            var context = services.GetService<AppDBContent>();
            string shopCardID = session.GetString("Id") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", shopCardID);

            return new ShopCart(context) { ShopCartId = shopCardID };
        }

        public void AddToCart(Car car)
        {
            this.appDbContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartID = ShopCartId,
                Car = car,
                Price = car.Price
            });
            appDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDbContent.ShopCartItems.Where(x => x.ShopCartID == ShopCartId).Include(x => x.Car).ToList();
        }
    }
}
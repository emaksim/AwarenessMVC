using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using System;

namespace Awarenessmvc.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopCartItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = item.Car.Id,
                    OrderID = order.Id,
                    Price = item.Car.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendsHairShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TrendsHairDbContext _trendsHairDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(TrendsHairDbContext trendsHairDbContext, ShoppingCart shoppingCart)
        {
            _trendsHairDbContext = trendsHairDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.HairQty,
                    HairId = shoppingCartItem.Hair.HairId,
                    Price = shoppingCartItem.Hair.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _trendsHairDbContext.Orders.Add(order);

            _trendsHairDbContext.SaveChanges();
        }
    }
}

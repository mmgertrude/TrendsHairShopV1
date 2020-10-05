using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TrendsHairShop.Models
{
    public class ShoppingCart
    {
        private readonly TrendsHairDbContext _trendsHairDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(TrendsHairDbContext trendsHairDbContext)
        {
            _trendsHairDbContext = trendsHairDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<TrendsHairDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Hair hair, int HairQty)
        {
            var shoppingCartItem =
                    _trendsHairDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Hair.HairId == hair.HairId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Hair = hair,
                    HairQty = 1
                };

                _trendsHairDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.HairQty++;
            }
            _trendsHairDbContext.SaveChanges();
        }

        public int RemoveFromCart(Hair hair)
        {
            var shoppingCartItem =
                    _trendsHairDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Hair.HairId == hair.HairId && s.ShoppingCartId == ShoppingCartId);

            var localHairQty = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.HairQty > 1)
                {
                    shoppingCartItem.HairQty--;
                    localHairQty = shoppingCartItem.HairQty;
                }
                else
                {
                    _trendsHairDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _trendsHairDbContext.SaveChanges();

            return localHairQty;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            /*
            The null-coalescing operator ?? returns the value of its left-hand operand if 
            it isn't null; otherwise, it evaluates the right-hand operand and returns its result. 
            The ?? operator doesn't evaluate its right-hand operand if the left-hand operand 
            evaluates to non-null.
            */
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                   _trendsHairDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Hair)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _trendsHairDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _trendsHairDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _trendsHairDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _trendsHairDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Hair.Price * c.HairQty).Sum();
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendsHairShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Hair Hair { get; set; }
        public int HairQty { get; set; }
        public string ShoppingCartId { get; set; }
    }
}

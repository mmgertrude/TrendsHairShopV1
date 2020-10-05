using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendsHairShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int HairId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Hair Hair { get; set; }
        public Order Order { get; set; }
    }
}

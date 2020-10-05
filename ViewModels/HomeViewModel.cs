using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendsHairShop.Models;

namespace TrendsHairShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Hair>  HairPiecesofTheWeek{ get; set; }
    }
}

using System.Collections.Generic;
using TrendsHairShop.Models;

namespace TrendsHairShop.ViewModels
{
    public class HairPiecesListViewModel
    {
        //add property for data to be displayed in the view
        public IEnumerable<Hair>  HairPieces{ get; set; }
        public string CurrentCategory { get; set; }
    }
}
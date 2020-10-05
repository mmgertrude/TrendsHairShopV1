using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendsHairShop.Models;
using TrendsHairShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrendsHairShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IHairRepository _hairRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IHairRepository hairRepository, ShoppingCart shoppingCart)
        {
            _hairRepository = hairRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int hairId)
        {
            var selectedHair = _hairRepository.GetAllHairPieces.FirstOrDefault(h => h.HairId == hairId);

            if (selectedHair != null)
            {
                _shoppingCart.AddToCart(selectedHair, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int hairId)
        {
            var selectedHair = _hairRepository.GetAllHairPieces.FirstOrDefault(h => h.HairId == hairId);

            if (selectedHair != null)
            {
                _shoppingCart.RemoveFromCart(selectedHair);
            }
            return RedirectToAction("Index");
        }
    }
}

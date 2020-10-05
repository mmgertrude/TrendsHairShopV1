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
    public class HomeController : Controller
    {
        
        private readonly IHairRepository _hairRepository;

        public HomeController(IHairRepository hairRepository)
        {
            _hairRepository = hairRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                HairPiecesofTheWeek = _hairRepository.GetAllHairPiecesofTheWeek
            };

            return View(homeViewModel);
        }
    }
}

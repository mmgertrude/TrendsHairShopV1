using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrendsHairShop.Models;
using TrendsHairShop.ViewModels;

namespace TrendsHairShop.Controllers
{
     /*Methods called Actions are invoked within the 
controller when a user sends a request:Eg

public ViewResult Index()   //Action method
{
return View();
}
*/
    public class HairPiecesController : Controller
    {
        private readonly IHairRepository _hairRepository;
        private readonly ICategoryRepository _categoryRepository;

/*Injecting IHairRepository and ICategory into the constractor here: 
this is possible because they have been registered in the startup class*/
        public HairPiecesController (IHairRepository hairRepository, ICategoryRepository categoryRepository)
         {
             //set the local _hairRepository to the one that is injected
             _hairRepository = hairRepository;
             _categoryRepository = categoryRepository;
         }
         
         /*note: the razorpage that this method works with should be 
         called ListOfHairPieces to correspond to this method name*/
         /*
         public ViewResult HairPiecesList()  
         {
            HairPiecesListViewModel hairPiecesListViewModel = new HairPiecesListViewModel();
            hairPiecesListViewModel.HairPieces = _hairRepository.GetAllHairPieces;
            hairPiecesListViewModel.CurrentCategory ="afros";
            return View(hairPiecesListViewModel);
         }
         */


        public ViewResult HairPiecesList(string category)
        {
            IEnumerable<Hair> hairPieces;
            string currentCategory;
             if (string.IsNullOrEmpty(category))
            {
                hairPieces = _hairRepository.GetAllHairPieces.OrderBy(h => h.HairId);
                currentCategory = "All Hair Pieces";
            }
            else
            {
                hairPieces = _hairRepository.GetAllHairPieces.Where(h => h.Category.CategoryName == category)
                    .OrderBy(h => h.HairId);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new HairPiecesListViewModel
            {
                HairPieces = hairPieces,
                CurrentCategory = currentCategory
            });
            
        }


        public IActionResult Details(int id)
        {
            var hair = _hairRepository.GetHairById(id);
            if (hair == null)
            {
                return NotFound();
            }
            return View(hair);
        }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendsHairShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace TrendsHairShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}

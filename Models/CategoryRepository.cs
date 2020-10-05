using System.Collections.Generic;

namespace TrendsHairShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TrendsHairDbContext _trendsHairDvContext;

        public CategoryRepository(TrendsHairDbContext trendsHairDbContext)
        {
            _trendsHairDvContext = trendsHairDbContext;
        }

        public IEnumerable<Category> GetAllCategories => _trendsHairDvContext.Categories;
    }
}
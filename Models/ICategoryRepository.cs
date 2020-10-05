using System.Collections.Generic;

namespace TrendsHairShop.Models
{
public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories{get;}
       
    }
}
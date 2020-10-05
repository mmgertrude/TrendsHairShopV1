
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TrendsHairShop.Models
{   public class HairRepository: IHairRepository
    {
        private readonly TrendsHairDbContext _trendsHairDbContext;
        public HairRepository (TrendsHairDbContext trendsHairDbContext)
        {
            _trendsHairDbContext = trendsHairDbContext;
        }

        public IEnumerable<Hair> GetAllHairPieces 
        {
            get
            {
                return _trendsHairDbContext.HairPieces.Include( c => c.Category);
            }
        }

        public IEnumerable<Hair> GetAllHairPiecesofTheWeek
        {
            get
            {
                return _trendsHairDbContext.HairPieces.Include( c => c.Category).Where(h=>h.IsHairOfTheWeek);
            }
        }

        public Hair GetHairById(int hairId)
        {
            return _trendsHairDbContext.HairPieces.FirstOrDefault(h =>h.HairId ==hairId);
        }
    }
}
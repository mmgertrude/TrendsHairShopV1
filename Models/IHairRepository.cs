using System.Collections.Generic;

namespace TrendsHairShop.Models
{
public interface IHairRepository
    {
        IEnumerable<Hair> GetAllHairPieces{get;}
        IEnumerable<Hair> GetAllHairPiecesofTheWeek{get;}
        Hair GetHairById(int hairId);

    }
}
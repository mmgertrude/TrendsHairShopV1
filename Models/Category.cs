using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrendsHairShop.Models
{
public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Hair> HairPieces { get; set; }
        




    }
}
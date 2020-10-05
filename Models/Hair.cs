using System.ComponentModel.DataAnnotations;

namespace TrendsHairShop.Models
{
public class Hair
    {
        [Key]
        public int HairId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool InStock { get; set; }
        public bool IsHairOfTheWeek { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
        




    }
}
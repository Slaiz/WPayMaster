using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Context
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        [MaxLength(50)]
        [Required]
        public string DrinkName { get; set; }
        [MaxLength(50)]
        [Required]
        public string DrinkType { get; set; }
        [Required]
        public int DrinkPrice { get; set; }
        [Required]
        public int Volume { get; set; }
    }
}
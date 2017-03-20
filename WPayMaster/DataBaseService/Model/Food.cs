using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Model
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [MaxLength(50)]
        [Required]
        public string FoodName { get; set; }
        [MaxLength(50)]
        [Required]
        public string FoodType { get; set; }
        [Required]
        public int FoodPrice { get; set; }
        [Required]
        public int FoodWeight { get; set; }
    }
}
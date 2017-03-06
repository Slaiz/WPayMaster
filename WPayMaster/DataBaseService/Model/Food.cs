using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Model
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public int FoodPrice { get; set; }
        public int CookTime { get; set; }
        public int FoodWeight { get; set; }
    }
}
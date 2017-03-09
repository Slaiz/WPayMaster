using System.IO.Packaging;
using DataBaseService;
using DataBaseService.Model;

namespace ViewModel.AdditionalViewModel
{
    public class EditFoodViewModel
    {
        public DbService DbService = new DbService();

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int CookTime { get; set; }
        public int Weight { get; set; }

        public EditFoodViewModel(Food item)
        {
            Name = item.FoodName;
            Type = item.FoodType;
            Price = item.FoodPrice;
            CookTime = item.CookTime;
            Weight = item.FoodWeight;
        }
    }
}
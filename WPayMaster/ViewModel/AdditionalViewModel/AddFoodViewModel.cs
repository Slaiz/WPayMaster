using System.Collections.Generic;
using DataBaseService;

namespace ViewModel.AdditionalViewModel
{
    public class AddFoodViewModel
    {
        public DbService DbService = new DbService();

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int CookTime { get; set; }
        public int Weight { get; set; }

        public List<string> FoodTypeList { get; set; } 

        public AddFoodViewModel()
        {
            FoodTypeList = new List<string>();

            foreach (var food in DbService.GetFoodsList())
            {
                FoodTypeList.Add(food.FoodType);
            }
        }
    }
}
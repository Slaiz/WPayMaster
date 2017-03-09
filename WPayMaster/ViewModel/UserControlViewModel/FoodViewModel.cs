using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;
using Shared.Enum;

namespace ViewModel.UserControlViewModel
{
    public class FoodViewModel
    {
        public static Food SelectedItem { get; set; }
        public int Count { get; set; }

        public ObservableCollection<Food> FoodList { get; set; }

        public DbService DbService = new DbService();

        public FoodViewModel()
        {
            FoodList = new ObservableCollection<Food>(DbService.GetFoodsList());
            Count = FoodList.Count;
        }
    }
}
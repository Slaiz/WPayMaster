using System;
using System.Collections.ObjectModel;
using System.Linq;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared.Enum;

namespace ViewModel.UserControlViewModel
{
    [ImplementPropertyChanged]
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

            DbService.OnAddFood += DoOnAddFood;
            DbService.OnUpdateFood += DoOnUpdateFood;
            DbService.OnDeleteFood += DoOnDeleteFood;
        }
        private void DoOnAddFood(object sender, Food food)
        {
            FoodList.Add(food);
            Count = FoodList.Count;
        }

        private void DoOnUpdateFood(Food oldFood, Food newFood)
        {
            var food = FoodList.First( x => x.FoodId == oldFood.FoodId);
            int index = FoodList.IndexOf(food);

            FoodList.RemoveAt(index);
            FoodList.Insert(index, newFood);
        }

        private void DoOnDeleteFood(object sender, Food food)
        {
            FoodList.Remove(food);
            Count = FoodList.Count;
        }

    }
}
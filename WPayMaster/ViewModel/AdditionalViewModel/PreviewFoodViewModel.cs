using System.Collections.Generic;
using System.Windows.Input;
using DataBaseService.Context;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class PreviewFoodViewModel
    {
        public ICommand CloseCommand { get; set; }

        public Food SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Recipe { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string ImagePath { get; set; }

        public List<string> FoodTypeList { get; set; }

        public PreviewFoodViewModel(Food item)
        {
            SelectedItem = item;

            Name = item.FoodName;
            Type = item.FoodType;
            Recipe = item.Recipe;
            Price = item.FoodPrice;
            Weight = item.FoodWeight;
            ImagePath = "E:\\Download\\Foto\\Coca Cola.jpg";
            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

using System.IO.Packaging;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class EditFoodViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

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

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateFood(FoodViewModel.SelectedItem, Name, Type, Price, CookTime, Weight);
        }

        private void Cancel()
        {
            Name = " ";
            Type = " ";
            Price = 0;
            CookTime = 0;
            Weight = 0;
        }
    }
}
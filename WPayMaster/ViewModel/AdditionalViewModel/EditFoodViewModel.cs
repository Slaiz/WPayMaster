using System.Collections.Generic;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditFoodViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public Food SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int CookTime { get; set; }
        public int Weight { get; set; }

        public List<string> FoodTypeList { get; set;}

        public EditFoodViewModel(Food item)
        {
            SelectedItem = item;

            Name = item.FoodName;
            Type = item.FoodType;
            Price = item.FoodPrice;
            CookTime = item.CookTime;
            Weight = item.FoodWeight;

            FoodTypeList = new List<string>(DbService.CreateTypeList(TypeView.AddFoodView));

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateFood(SelectedItem, Name, Type, Price, CookTime, Weight);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel()
        {
            Name = " ";
            Type = null;
            Price = 0;
            CookTime = 0;
            Weight = 0;
        }
    }
}
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditFoodViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public Food SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public List<string> FoodTypeList { get; set;}

        public EditFoodViewModel(Food item)
        {
            SelectedItem = item;

            Name = item.FoodName;
            Type = item.FoodType;
            Price = item.FoodPrice;
            Weight = item.FoodWeight;

            FoodTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddFoodView));

            CloseCommand = new CommandHandler(arg => Close());
            SaveItemCommand = new CommandHandler(arg => SaveItem());
            ClearCommand = new CommandHandler(arg => Clear());
        }

        private void Clear()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Weight = 0;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateFood(SelectedItem, Name, Type, Price, Weight);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
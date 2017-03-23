using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using PropertyChanged;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class AddFoodViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public List<string> FoodTypeList { get; set; } 

        public AddFoodViewModel()
        {
            FoodTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddFoodView));
                
            CloseCommand = new CommandHandler(arg => Close());
            AddItemCommand = new CommandHandler(arg => AddItem());
            ClearCommand = new CommandHandler(arg => Clear());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void AddItem()
        {
            DbService.AddFood(Name, Type, Price, Weight);

            MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Clear()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Weight = 0;
        }
    }
}
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditDrinkViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public Drink SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }

        public List<string> DrinkTypeList { get; set; }

        public EditDrinkViewModel(Drink item)
        {
            SelectedItem = item;

            Name = item.DrinkName;
            Type = item.DrinkType;
            Price = item.DrinkPrice;
            Volume = item.Volume;

            DrinkTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddDrinkView));
            
            CloseCommand = new CommandHandler(arg => Close());
            SaveItemCommand = new CommandHandler(arg => SaveItem());
            ClearCommand = new CommandHandler(arg => Clear());
        }

        private void Clear()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Volume = 0;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateDrink(SelectedItem, Name, Type, Price, Volume);


            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
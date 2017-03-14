using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using PropertyChanged;
using Shared;
using Shared.Enum;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class AddDrinkViewModel
    {
        public DbService DbService = new DbService();

        public ICommand AddItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }

        public List<string> DrinkTypeList { get; set; }

        public AddDrinkViewModel()
        {
            DrinkTypeList = new List<string>(DbService.CreateTypeList(TypeView.AddDrinkView));

            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg =>Cancel());
        }

        private void AddItem()
        {
            DbService.AddDrink(Name, Type, Price, Volume);

            MessageBox.Show("Запис додано","Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Cancel()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Volume = 0;
        }
    }
}
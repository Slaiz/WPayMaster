using System.Collections.Generic;
using System.Windows.Input;
using DataBaseService;
using PropertyChanged;
using Shared;

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
            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg =>Cancel());
        }

        private void AddItem()
        {
            DbService.AddDrink(Name, Type, Price, Volume);
        }

        private void Cancel()
        {
            Name = " ";
            Type = " ";
            Price = 0;
            Volume = 0;
        }
    }
}
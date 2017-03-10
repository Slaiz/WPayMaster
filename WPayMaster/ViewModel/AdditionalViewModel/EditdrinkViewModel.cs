using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class EditDrinkViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }

        public EditDrinkViewModel(Drink item)
        {
            Name = item.DrinkName;
            Type = item.DrinkType;
            Price = item.DrinkPrice;
            Volume = item.Volume;

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateDrink(DrinkViewModel.SelectedItem, Name, Type, Price, Volume);
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
using System.Windows.Input;
using DataBaseService.Context;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class PreviewDrinkViewModel
    {
        public ICommand CloseCommand { get; set; }

        public Drink SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public string ImagePath { get; set; }

        public PreviewDrinkViewModel(Drink item)
        {
            SelectedItem = item;

            Name = item.DrinkName;
            Type = item.DrinkType;
            Price = item.DrinkPrice;
            Volume = item.Volume;
            ImagePath = "E:\\Download\\Foto\\Coca Cola.jpg";

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

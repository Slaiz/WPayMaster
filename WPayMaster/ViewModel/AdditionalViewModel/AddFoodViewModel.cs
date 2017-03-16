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
    public class AddFoodViewModel
    {
        public DbService DbService = new DbService();

        public ICommand AddItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int CookTime { get; set; }
        public int Weight { get; set; }

        public List<string> FoodTypeList { get; set; } 

        public AddFoodViewModel()
        {
            FoodTypeList = new List<string>(DbService.CreateTypeList(TypeView.AddFoodView));
                
            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void AddItem()
        {
            DbService.AddFood(Name, Type, Price, CookTime, Weight);

            MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
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
using System.Collections.Generic;
using System.Windows.Input;
using DataBaseService;
using Shared;

namespace ViewModel.AdditionalViewModel
{
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
            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void AddItem()
        {
            DbService.AddFood(Name, Type, Price, CookTime, Weight);
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
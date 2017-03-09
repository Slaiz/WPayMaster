using DataBaseService;
using DataBaseService.Model;

namespace ViewModel.AdditionalViewModel
{
    public class EditDrinkViewModel
    {
        public DbService DbService = new DbService();

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
        }
    }
}
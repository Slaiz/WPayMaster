using System.Collections.Generic;
using DataBaseService;
using PropertyChanged;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class AddDrinkViewModel
    {
        public DbService DbService = new DbService();
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }

        public List<string> DrinkTypeList { get; set; }

        public AddDrinkViewModel()
        {
            DrinkTypeList = new List<string>();

            foreach (var drink in DbService.GetDrinksList())
            {
                DrinkTypeList.Add(drink.DrinkType);
            }
        } 
    }
}
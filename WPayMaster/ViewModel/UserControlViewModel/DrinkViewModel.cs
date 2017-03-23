using System.Collections.ObjectModel;
using System.Linq;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using PropertyChanged;

namespace ViewModel.UserControlViewModel
{
    [ImplementPropertyChanged]
    public class DrinkViewModel
    {
        public static Drink SelectedItem { get; set; }
        public int Count { get; set;}
        public ObservableCollection<Drink> DrinkList { get; set; }

        public DbService DbService = new DbService();

        public DrinkViewModel()
        {
            DrinkList = new ObservableCollection<Drink>(DbService.GetDrinksList());
            Count = DrinkList.Count;

            DbService.OnAddDrink += DoOnAddDrink;
            DbService.OnUpdateDrink += DoOnUpdateDrink;
            DbService.OnDeleteDrink += DoOnDeleteDrink;
        }

        private void DoOnAddDrink(object sender, Drink drink)
        {
            DrinkList.Add(drink);
            Count = DrinkList.Count;
        }

        private void DoOnUpdateDrink(Drink oldDrink, Drink newDrink)
        {
            var drink = DrinkList.First(x => x.DrinkId == oldDrink.DrinkId);
            int index = DrinkList.IndexOf(drink);

            DrinkList.RemoveAt(index);
            DrinkList.Insert(index, newDrink);
        }

        private void DoOnDeleteDrink(object sender, Drink drink)
        {
            var oldDrink = DrinkList.First(x => x.DrinkId == drink.DrinkId);

            DrinkList.Remove(oldDrink);
            Count = DrinkList.Count;
        }
    }
}
using System;
using System.Collections.ObjectModel;
using System.Linq;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared.Enum;

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
            DrinkList = new ObservableCollection<Drink>();
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

        private void DoOnUpdateDrink(Drink oldItem, Drink newItem)
        {
            var drink = DrinkList.First(x => x.DrinkId == oldItem.DrinkId);
            int index = DrinkList.IndexOf(drink);

            DrinkList.RemoveAt(index);
            DrinkList.Insert(index, newItem);
        }

        private void DoOnDeleteDrink(object sender, Drink drink)
        {
            DrinkList.Remove(drink);
            Count = DrinkList.Count;
        }
    }
}
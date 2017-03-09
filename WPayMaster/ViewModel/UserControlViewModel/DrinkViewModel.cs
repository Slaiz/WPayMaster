using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;
using Shared.Enum;

namespace ViewModel.UserControlViewModel
{

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
        }
    }
}
using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;
using Shared.Enum;

namespace ViewModel.ItemListViewModel
{
    public class SaladListViewModel
    {
        public DbService DbService = new DbService();

        public ObservableCollection<Order> SaladList { get; set; }

        public SaladListViewModel()
        {
            SaladList = new ObservableCollection<Order>(DbService.GetFoodOrderList(FoodType.Салат));

        }
    }
}
using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;
using Shared.Enum;

namespace ViewModel.ItemListViewModel
{
    public class SaladListViewModel
    {
        public DbService DbService = new DbService();

        public ObservableCollection<Food> SaladList { get; set; }

        public SaladListViewModel()
        {
            SaladList = new ObservableCollection<Food>(DbService.GetTypeFoodList(FoodType.Салат));

        }
    }
}
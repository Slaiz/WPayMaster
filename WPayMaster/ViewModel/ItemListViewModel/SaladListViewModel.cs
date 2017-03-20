using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enum;

namespace ViewModel.ItemListViewModel
{
    public class SaladListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }

        public ObservableCollection<Order> SaladList { get; set; }

        public SaladListViewModel()
        {
            SaladList = new ObservableCollection<Order>(DbService.GetFoodOrderList(FoodType.Салат));

            PlusCommand = new CommandHandler(arg => Plus());
            MinusCommand = new CommandHandler(arg => Minus());
        }

        private void Minus()
        {
            throw new System.NotImplementedException();
        }

        private void Plus()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    [ImplementPropertyChanged]
    public class ColdDrinkListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> ColdDrinksList { get; set; }

        public ColdDrinkListViewModel()
        {
            ColdDrinksList = new ObservableCollection<OrderModel>(DbService.GetDrinkOrderList(DrinkType.Холоднийнапій));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var coldDrink in ColdDrinksList)
            {
                if (coldDrink.Count.ItemCount >= 1)
                {
                    coldDrink.Sum = coldDrink.ItemPrice * coldDrink.Count.ItemCount;
                    orderList.Add(coldDrink);
                }
            }

            DbService.DoOnAddOrders(orderList, 0);

            LoginViewModel.DoOnCloseView();
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}
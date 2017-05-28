using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    public class HotDrinkListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> HotDrinksList { get; set; }

        public HotDrinkListViewModel()
        {
            HotDrinksList = new ObservableCollection<OrderModel>(DbService.GetDrinkOrderList(DrinkType.Гарячийнапій));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var hotDrinks in HotDrinksList)
            {
                if (hotDrinks.Count.ItemCount >= 1)
                {
                    hotDrinks.Sum = hotDrinks.ItemPrice * hotDrinks.Count.ItemCount;
                    orderList.Add(hotDrinks);
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
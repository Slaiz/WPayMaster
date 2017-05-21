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
    public class JuiceListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> JuicesList { get; set; }

        public JuiceListViewModel()
        {
            JuicesList = new ObservableCollection<OrderModel>(DbService.GetDrinkOrderList(DrinkType.Сік));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var juice in JuicesList)
            {
                if (juice.Count.ItemCount >= 1)
                {
                    juice.Sum = juice.ItemPrice * juice.Count.ItemCount;
                    orderList.Add(juice);
                }
            }

            DbService.DoOnAddOrders(orderList);

            LoginViewModel.DoOnCloseView();
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}
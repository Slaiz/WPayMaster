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
    public class SauceListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> SaucesList { get; set; }

        public SauceListViewModel()
        {
            SaucesList = new ObservableCollection<OrderModel>(DbService.GetModificatorOrderList(ModificatorType.Соус));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var sauce in SaucesList)
            {
                if (sauce.Count.ItemCount >= 1)
                {
                    sauce.Sum = sauce.ItemPrice * sauce.Count.ItemCount;
                    orderList.Add(sauce);
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
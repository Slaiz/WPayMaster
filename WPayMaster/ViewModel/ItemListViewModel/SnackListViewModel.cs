using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enum;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    public class SnackListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> SnacksList { get; set; }

        public SnackListViewModel()
        {
            SnacksList = new ObservableCollection<OrderModel>(DbService.GetModificatorOrderList(ModificatorType.Закуска));

            CloseCommand = new CommandHandler(arg => Close());
            AddOrderToCheckCommand = new CommandHandler(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var snack in SnacksList)
            {
                if (snack.Count.ItemCount >= 1)
                {
                    snack.Sum = snack.ItemPrice * snack.Count.ItemCount;
                    orderList.Add(snack);
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
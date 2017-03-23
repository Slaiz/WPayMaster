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
    public class GarnishListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> GarnishsList { get; set; }

        public GarnishListViewModel()
        {
            GarnishsList = new ObservableCollection<OrderModel>(DbService.GetFoodOrderList(FoodType.Гарнір));

            CloseCommand = new CommandHandler(arg => Close());
            AddOrderToCheckCommand = new CommandHandler(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var salad in GarnishsList)
            {
                if (salad.Count.ItemCount >= 1)
                {
                    salad.Sum = salad.ItemPrice * salad.Count.ItemCount;
                    orderList.Add(salad);
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    [ImplementPropertyChanged]
    public class SaladListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> SaladsList { get; set; }

        public SaladListViewModel()
        {
            SaladsList = new ObservableCollection<OrderModel>(DbService.GetFoodOrderList(FoodType.Салат));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var salad in SaladsList)
            {
                if (salad.Count.ItemCount >= 1)
                {
                    salad.Sum = salad.ItemPrice * salad.Count.ItemCount;
                    orderList.Add(salad);
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
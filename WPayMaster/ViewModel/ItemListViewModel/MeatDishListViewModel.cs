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
    public class MeatDishListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> MeatDishsList { get; set; }

        public MeatDishListViewModel()
        {
            MeatDishsList = new ObservableCollection<OrderModel>(DbService.GetFoodOrderList(FoodType.Мяснастрава));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var meatDish in MeatDishsList)
            {
                if (meatDish.Count.ItemCount >= 1)
                {
                    meatDish.Sum = meatDish.ItemPrice * meatDish.Count.ItemCount;
                    orderList.Add(meatDish);
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
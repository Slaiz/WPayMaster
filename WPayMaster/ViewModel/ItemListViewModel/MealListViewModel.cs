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
    public class MealListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> MealsList { get; set; }

        public MealListViewModel()
        {
            MealsList = new ObservableCollection<OrderModel>(DbService.GetFoodOrderList(FoodType.Борошнянийвиріб));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var meal in MealsList)
            {
                if (meal.Count.ItemCount >= 1)
                {
                    meal.Sum = meal.ItemPrice * meal.Count.ItemCount;
                    orderList.Add(meal);
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
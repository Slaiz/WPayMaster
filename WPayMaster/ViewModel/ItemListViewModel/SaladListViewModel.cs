using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enum;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    public class SaladListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }

        public ObservableCollection<Order> SaladsList { get; set; }

        public Order SelectedItem { get; set; }

        public SaladListViewModel()
        {
            SaladsList = new ObservableCollection<Order>(DbService.GetFoodOrderList(FoodType.Салат));

            CloseCommand = new CommandHandler(arg => Close());
            AddOrderToCheckCommand = new CommandHandler(arg => AddOrderToCheck());
            PlusCommand = new CommandHandler(arg => Plus());
            MinusCommand = new CommandHandler(arg => Minus());

            SelectedItem = SaladsList[0];
        }

        private void AddOrderToCheck()
        {
            var orderList = new List<Order>();

            foreach (var salad in SaladsList)
            {
                if (salad.Count >= 1)
                {
                    salad.Sum = salad.ItemPrice*salad.Count;
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

        private void Minus()
        {
            SelectedItem.Count -= 1;
        }

        private void Plus()
        {
            SelectedItem.Count += 1;
        }
    }
}
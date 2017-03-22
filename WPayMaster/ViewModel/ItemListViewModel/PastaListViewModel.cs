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
    public class PastaListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> PastasList { get; set; }

        public PastaListViewModel()
        {
            PastasList = new ObservableCollection<OrderModel>(DbService.GetFoodOrderList(FoodType.Паста));

            CloseCommand = new CommandHandler(arg => Close());
            AddOrderToCheckCommand = new CommandHandler(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var pasta in PastasList)
            {
                if (pasta.Count.ItemCount >= 1)
                {
                    pasta.Sum = pasta.ItemPrice * pasta.Count.ItemCount;
                    orderList.Add(pasta);
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
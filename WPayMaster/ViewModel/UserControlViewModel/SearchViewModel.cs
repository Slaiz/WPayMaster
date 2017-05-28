using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.UserControlViewModel
{
    public class SearchViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public IEnumerable<OrderModel> SearchList { get; set; }

        public SearchViewModel(string searchText)
        {
            SearchList = new ObservableCollection<OrderModel>(DbService.GetSearchOrderList());

            if (searchText != null)
                SearchList = SearchList.Where(item => item.ItemName.ToLower().Contains(searchText.ToLower()));
            else
            {
                SearchList = null;
            }

            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());
        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var searchItem in SearchList)
            {
                if (searchItem.Count.ItemCount >= 1)
                {
                    searchItem.Sum = searchItem.ItemPrice * searchItem.Count.ItemCount;
                    orderList.Add(searchItem);
                }
            }

            DbService.DoOnAddOrders(orderList, 1);

            LoginViewModel.DoOnCloseView();
        }
    }
}
﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    public class SoupListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> SoupsList { get; set; }

        public SoupListViewModel()
        {
            SoupsList = new ObservableCollection<OrderModel>(DbService.GetFoodOrderList(FoodType.Першастрава));

            CloseCommand = new Command(arg => Close());
            AddOrderToCheckCommand = new Command(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var soup in SoupsList)
            {
                if (soup.Count.ItemCount >= 1)
                {
                    soup.Sum = soup.ItemPrice * soup.Count.ItemCount;
                    orderList.Add(soup);
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
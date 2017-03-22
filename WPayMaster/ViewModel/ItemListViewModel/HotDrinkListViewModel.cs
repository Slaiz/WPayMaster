﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using Shared.Enum;
using ViewModel.MainViewModel;

namespace ViewModel.ItemListViewModel
{
    public class HotDrinkListViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddOrderToCheckCommand { get; set; }

        public ObservableCollection<OrderModel> HotDrinksList { get; set; }

        public HotDrinkListViewModel()
        {
            HotDrinksList = new ObservableCollection<OrderModel>(DbService.GetDrinkOrderList(DrinkType.Гарячінапій));

            CloseCommand = new CommandHandler(arg => Close());
            AddOrderToCheckCommand = new CommandHandler(arg => AddOrderToCheck());

        }

        private void AddOrderToCheck()
        {
            var orderList = new List<OrderModel>();

            foreach (var hotDrinks in HotDrinksList)
            {
                if (hotDrinks.Count.ItemCount >= 1)
                {
                    hotDrinks.Sum = hotDrinks.ItemPrice * hotDrinks.Count.ItemCount;
                    orderList.Add(hotDrinks);
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
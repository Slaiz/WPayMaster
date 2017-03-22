﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using Shared.Interface;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class CashierViewModel
    {
        public static event EventHandler<ViewType> OnLogOut;
        public Func<object, ViewType, IView> CreateViewAction { get; set; }

        #region Command
        public ICommand LogOutCommand { get; set; }
        public ICommand StartWorkCommand { get; set; }
        public ICommand StopWorkCommand { get; set; }
        public ICommand ChangeColorCommand { get; set; }
        public ICommand OpenCheckHistoryViewCommand { get; set; }
        public ICommand FindCommand { get; set; }
        public ICommand CheckCommand { get; set; }
        public ICommand CleanCheckCommand { get; set; }
        public ICommand DeleteItemCheckCommand { get; set; }
        public ICommand OpenColdDrinkListViewCommand { get; set; }
        public ICommand OpenDessertListViewCommand { get; set; }
        public ICommand OpenFishListViewCommand { get; set; }
        public ICommand OpenGarnishListViewCommand { get; set; }
        public ICommand OpenHotDrinkListViewCommand { get; set; }
        public ICommand OpenJuiceListViewCommand { get; set; }
        public ICommand OpenMealListViewCommand { get; set; }
        public ICommand OpenMeatDishListViewCommand { get; set; }
        public ICommand OpenPastaListViewCommand { get; set; }
        public ICommand OpenPizzaListViewCommand { get; set; }
        public ICommand OpenSaladListViewCommand { get; set; }
        public ICommand OpenSauceListViewCommand { get; set; }
        public ICommand OpenSnackListViewCommand { get; set; }
        public ICommand OpenSoupListViewCommand { get; set; }
        #endregion

        public DbService DbService = new DbService();

        public ObservableCollection<OrderModel> OrdersList { get; set; }

        public User Cashier { get; set; }
        public string CashierName { get; set; }
        public OrderModel SelectedItem { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime StartWorkTime { get; set; }
        public Brush PanelBrushColor { get; set; }
        public int Sum { get; set; }

        private Color[] Colors = new Color[]
        {
            Color.FromRgb(33, 150, 243), Color.FromRgb(29, 233, 182), Color.FromRgb(233, 30, 99),
            Color.FromRgb(255, 152, 0), Color.FromRgb(255, 87, 34),Color.FromRgb(96, 125, 139),
            Color.FromRgb(213, 0, 0), Color.FromRgb(103, 58, 183)
        };

        public CashierViewModel(Func<object, ViewType, IView> createViewAction, User user)
        {
            CreateViewAction = createViewAction;

            OrdersList = new ObservableCollection<OrderModel>();

            PanelBrushColor = LoginViewModel.ThemeBrushColor;

            Cashier = user;
            CashierName = user.UserName + " " + user.Surname;

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1),
            DispatcherPriority.Normal,
            delegate
            {
                CurrentTime = DateTime.Now;
            },
            Dispatcher.CurrentDispatcher);

            DbService.OnAddOrders += DbServiceOnOnAddOrders;

            LogOutCommand = new CommandHandler(arg => LogOut());
            StartWorkCommand = new CommandHandler(arg => StartWork());
            StopWorkCommand = new CommandHandler(arg => StopWork());
            ChangeColorCommand = new CommandHandler(arg => ChangeColor());
            OpenCheckHistoryViewCommand = new CommandHandler(arg => OpenCheckHistoryView());

            FindCommand = new CommandHandler(arg => Find());
            CheckCommand = new CommandHandler(arg => Check());
            CleanCheckCommand = new CommandHandler(arg => CleanCheck());
            DeleteItemCheckCommand = new CommandHandler(arg => DeleteItemCheck());

            OpenColdDrinkListViewCommand = new CommandHandler(arg => OpenColdDrinkListView());
            OpenDessertListViewCommand = new CommandHandler(arg => OpenDessertListView());
            OpenFishListViewCommand = new CommandHandler(arg => OpenFishListView());
            OpenGarnishListViewCommand = new CommandHandler(arg => OpenGarnishListView());
            OpenHotDrinkListViewCommand = new CommandHandler(arg => OpenHotDrinkListView());
            OpenJuiceListViewCommand = new CommandHandler(arg => OpenJuiceListView());
            OpenMealListViewCommand = new CommandHandler(arg => OpenMealListView());
            OpenMeatDishListViewCommand = new CommandHandler(arg => OpenMeatDishListView());
            OpenPastaListViewCommand = new CommandHandler(arg => OpenPastaListView());
            OpenPizzaListViewCommand = new CommandHandler(arg => OpenPizzaListView());
            OpenSaladListViewCommand = new CommandHandler(arg => OpenSaladListView());
            OpenSauceListViewCommand = new CommandHandler(arg => OpenSauceListView());
            OpenSnackListViewCommand = new CommandHandler(arg => OpenSnackListView());
            OpenSoupListViewCommand = new CommandHandler(arg => OpenSoupListView());
        }

        private void DeleteItemCheck()
        {
            OrdersList.Remove(SelectedItem);
        }

        private void DbServiceOnOnAddOrders(object sender, List<OrderModel> ordersList)
        {
            foreach (var order in ordersList)
            {
                var item = OrdersList.FirstOrDefault(x => x.ItemName == order.ItemName);

                if (item != null)
                {
                    int index = OrdersList.IndexOf(item);

                    item.Sum = item.Count.ItemCount * item.ItemPrice;
                    item.Count.ItemCount += order.Count.ItemCount;                 
                    item.Sum += order.Count.ItemCount * item.ItemPrice;

                    OrdersList.RemoveAt(index);
                    OrdersList.Insert(index, item);
                }
                else OrdersList.Add(order);
            }

            Sum = 0;

            foreach (var order in OrdersList)
            {
                Sum += order.Sum;
            }
        }

        private void CleanCheck()
        {
            OrdersList.Clear();
            Sum = 0;
        }

        private void Check()
        {
            DbService.AddOrder(OrdersList.ToList());

            OrdersList.Clear();

            Sum = 0;

            MessageBox.Show("Заказ принято", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Find()
        {
            throw new NotImplementedException();
        }

        private void ChangeColor()
        {
            Random r = new Random();

            PanelBrushColor = new SolidColorBrush(Colors[r.Next(1, 8)]);

            LoginViewModel.ThemeBrushColor = PanelBrushColor;
        }

        private void LogOut()
        {
            DoOnLogOut(ViewType.CashierView);
        }

        private void StartWork()
        {
            StartWorkTime = DateTime.Now;
        }

        private void StopWork()
        {
            DbService.AddWorkingTime(Cashier, CurrentTime - StartWorkTime);
        }

        private void OpenCheckHistoryView()
        {
            CreateViewAction.Invoke(null, ViewType.CheckHistoryView);
        }

        #region MethodOpenItemListView
        private static void DoOnLogOut(ViewType e)
        {
            OnLogOut?.Invoke(null, e);
        }

        private void OpenSnackListView()
        {
            CreateViewAction.Invoke(null, ViewType.SnackListView);
        }

        private void OpenSauceListView()
        {
            CreateViewAction.Invoke(null, ViewType.SauceListView);
        }

        private void OpenSaladListView()
        {
            CreateViewAction.Invoke(null, ViewType.SaladListView);
        }

        private void OpenPizzaListView()
        {
            CreateViewAction.Invoke(null, ViewType.PizzaListView);
        }

        private void OpenPastaListView()
        {
            CreateViewAction.Invoke(null, ViewType.PastaListView);
        }

        private void OpenMeatDishListView()
        {
            CreateViewAction.Invoke(null, ViewType.MeatDishListView);
        }

        private void OpenMealListView()
        {
            CreateViewAction.Invoke(null, ViewType.MealListView);
        }

        private void OpenJuiceListView()
        {
            CreateViewAction.Invoke(null, ViewType.JuiceListView);
        }

        private void OpenHotDrinkListView()
        {
            CreateViewAction.Invoke(null, ViewType.HotDrinkListView);
        }

        private void OpenGarnishListView()
        {
            CreateViewAction.Invoke(null, ViewType.GarnishListView);
        }

        private void OpenFishListView()
        {
            CreateViewAction.Invoke(null, ViewType.FishListView);
        }

        private void OpenDessertListView()
        {
            CreateViewAction.Invoke(null, ViewType.DessertListView);
        }

        private void OpenColdDrinkListView()
        {
            CreateViewAction.Invoke(null, ViewType.ColdDrinkListView);
        }

        private void OpenSoupListView()
        {
            CreateViewAction.Invoke(null, ViewType.SoupListView);
        }
        #endregion
    }
}
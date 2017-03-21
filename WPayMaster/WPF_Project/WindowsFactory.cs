using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using DataBaseService.Model;
using Shared.Enum;
using Shared.Interface;
using ViewModel.AdditionalViewModel;
using ViewModel.ItemListViewModel;
using ViewModel.MainViewModel;
using WPF_Project.View;
using WPF_Project.View.AdditionalViews;
using WPF_Project.View.ItemListViews;
using WPF_Project.View.ListOrederView;
using WPF_Project.View.MainViews;

namespace WPF_Project
{
    public class WindowsFactory
    {
        private SplashScreenView splashScreenView;
        private LoginView loginView;
        private CashierView cashierView;
        private AdminView adminView;
        private List<Window> MainViewList = new List<Window>();
        private static List<IView> AdditionalViewList = new List<IView>();  

        public WindowsFactory()
        {

        }

        public void StartLoginView()
        {
            splashScreenView = new SplashScreenView();
            splashScreenView.DataContext = new SplashScreenViewModel();
            splashScreenView.Show();
            //SplashScreenViewModel.DoOnStartUp();
            Thread.Sleep(200);

            LoginViewModel.OnLogIn += LoginViewModelOnOnLogIn;
            LoginViewModel.OnCloseView += LoginViewModelOnOnCloseView;
            loginView = new LoginView();
            loginView.DataContext = new LoginViewModel(CreateViewAction);

            splashScreenView.Close();

            loginView.Show();
            AddMainView(loginView, null);
        }

        private void LoginViewModelOnOnCloseView()
        {
            foreach (var view in AdditionalViewList)
            {
                view.CloseView();
            }

            AdditionalViewList.Clear();
        }

        private void LoginViewModelOnOnLogIn(ViewType viewType, User user)
        {
            switch (viewType)
            {
                case ViewType.CashierView:
                    {
                        cashierView = new CashierView();
                        cashierView.DataContext = new CashierViewModel(CreateViewAction, user);
                        loginView.Close();
                        cashierView.Show();
                        AddMainView(cashierView, loginView);
                        CashierViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
                case ViewType.AdminView:
                    {
                        adminView = new AdminView();
                        adminView.DataContext = new AdminViewModel(CreateViewAction, user);
                        loginView.Close();
                        adminView.Show();
                        AddMainView(adminView, loginView);
                        AdminViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
            }
        }

        private void MethodOnLogOut(object sender, ViewType viewType)
        {
            CashierViewModel.OnLogOut -= MethodOnLogOut;
            AdminViewModel.OnLogOut -= MethodOnLogOut;

            loginView = new LoginView();
            loginView.DataContext = new LoginViewModel(CreateViewAction);
            CloseAllMainView();
            AddMainView(loginView, null);
            loginView.Show();
        }

        public static IView CreateViewAction(object o, ViewType viewType)
        {
            IView view;

            switch (viewType)
            {
                case ViewType.AddUserView:
                    {
                        view = new AddUserView(new AddUserViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }

                case ViewType.AddFoodView:
                    {
                        view = new AddFoodView(new AddFoodViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.AddDrinkView:
                    {
                        view = new AddDrinkView(new AddDrinkViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.AddModificatorView:
                    {
                        view = new AddModificatorView(new AddModificatorViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.EditUserView:
                    {
                        view = new EditUserView(new EditUserViewModel((User)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.EditFoodView:
                    {
                        view = new EditFoodView(new EditFoodViewModel((Food)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.EditDrinkView:
                    {
                        view = new EditDrinkView(new EditDrinkViewModel((Drink)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.EditModificatorView:
                    {
                        view = new EditModificatorView(new EditModificatorViewModel((Modificator)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.ActivityHistoryView:
                    {
                        view = new ActivityHistoryView(new ActivityHistoryViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.CheckHistoryView:
                    {
                        view = new CheckHistoryView(new CheckHistoryViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.LoginView:
                {
                        view = null;
                        KillAllView();
                        break;
                    }
                case ViewType.ColdDrinkListView:
                    {
                        view = new ColdDrinkListView(new ColdDrinkListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.DessertListView:
                    {
                        view = new DessertListView(new DessertListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.FishListView:
                    {
                        view = new FishListView(new FishListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.GarnishListView:
                    {
                        view = new GarnishListView(new GarnishListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.HotDrinkListView:
                    {
                        view = new HotDrinkListView(new HotDrinkListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.JuiceListView:
                    {
                        view = new JuiceListView(new JuiceListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.MealListView:
                    {
                        view = new MealListView(new MealListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.MeatDishListView:
                    {
                        view = new MeatDishListView(new MeatDishListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.PastaListView:
                    {
                        view = new PastaListView(new PastaListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.PizzaListView:
                    {
                        view = new PizzaListView(new PizzaListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.SaladListView:
                    {
                        view = new SaladListView(new SaladListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.SauceListView:
                    {
                        view = new SauceListView(new SauceListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.SnackListView:
                    {
                        view = new SnackListView(new SnackListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case ViewType.SoupListView:
                    {
                        view = new SoupListView(new SoupListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                default:
                    {
                        view = null;
                        break;
                    }
            }

            return view;
        }

        public static void KillAllView()
        {
            Application.Current.Shutdown();
        }

        public void CloseAllMainView()
        {
            foreach (var view in MainViewList)
            {
                view.Close();
            }

            MainViewList.Clear();
        }

        public void AddMainView(Window view1,Window view2)
        {
            MainViewList.Add(view1);
            MainViewList.Remove(view2);
        }

        public static void AddAdditionalView(IView view)
        {
            AdditionalViewList.Add(view);
        }
    }

}
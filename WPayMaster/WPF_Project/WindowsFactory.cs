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

        private void LoginViewModelOnOnLogIn(TypeView typeView, User user)
        {
            switch (typeView)
            {
                case TypeView.CashierView:
                    {
                        cashierView = new CashierView();
                        cashierView.DataContext = new CashierViewModel(CreateViewAction, user);
                        loginView.Close();
                        cashierView.Show();
                        AddMainView(cashierView, loginView);
                        CashierViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
                case TypeView.AdminView:
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

        private void MethodOnLogOut(object sender, TypeView typeView)
        {
            CashierViewModel.OnLogOut -= MethodOnLogOut;
            AdminViewModel.OnLogOut -= MethodOnLogOut;

            loginView = new LoginView();
            loginView.DataContext = new LoginViewModel(CreateViewAction);
            CloseAllMainView();
            AddMainView(loginView, null);
            loginView.Show();
        }

        public static IView CreateViewAction(object o, TypeView typeView)
        {
            IView view;

            switch (typeView)
            {
                case TypeView.AddUserView:
                    {
                        view = new AddUserView(new AddUserViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }

                case TypeView.AddFoodView:
                    {
                        view = new AddFoodView(new AddFoodViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.AddDrinkView:
                    {
                        view = new AddDrinkView(new AddDrinkViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.AddModificatorView:
                    {
                        view = new AddModificatorView(new AddModificatorViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.EditUserView:
                    {
                        view = new EditUserView(new EditUserViewModel((User)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.EditFoodView:
                    {
                        view = new EditFoodView(new EditFoodViewModel((Food)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.EditDrinkView:
                    {
                        view = new EditDrinkView(new EditDrinkViewModel((Drink)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.EditModificatorView:
                    {
                        view = new EditModificatorView(new EditModificatorViewModel((Modificator)o));
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.HistoryView:
                    {
                        view = new HistoryView(new HistoryViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.LoginView:
                {
                        view = null;
                        KillAllView();
                        break;
                    }
                case TypeView.ColdDrinkListView:
                    {
                        view = new ColdDrinkListView(new ColdDrinkListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.DessertListView:
                    {
                        view = new DessertListView(new DessertListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.FishListView:
                    {
                        view = new FishListView(new FishListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.GarnishListView:
                    {
                        view = new GarnishListView(new GarnishListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.HotDrinkListView:
                    {
                        view = new HotDrinkListView(new HotDrinkListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.JuiceListView:
                    {
                        view = new JuiceListView(new JuiceListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.MealListView:
                    {
                        view = new MealListView(new MealListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.MeatDishListView:
                    {
                        view = new MeatDishListView(new MeatDishListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.PastaListView:
                    {
                        view = new PastaListView(new PastaListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.PizzaListView:
                    {
                        view = new PizzaListView(new PizzaListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.SaladListView:
                    {
                        view = new SaladListView(new SaladListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.SauceListView:
                    {
                        view = new SauceListView(new SauceListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.SnackListView:
                    {
                        view = new SnackListView(new SnackListViewModel());
                        AddAdditionalView(view);
                        view.ShowView();
                        break;
                    }
                case TypeView.SoupListView:
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
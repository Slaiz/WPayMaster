using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using DataBaseService.Interface;
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
        private LoginView loginView;
        private OrderView orderView;
        private AdminView adminView;
        private List<Window> ViewList = new List<Window>(); 

        public WindowsFactory()
        {

        }

        public static void CloseWindow(Window view)
        {
            view.Close();
        }

        public void StartLoginView()
        {
            LoginViewModel.OnLogIn += LoginViewModelOnOnLogIn;
            loginView = new LoginView();
            loginView.DataContext = new LoginViewModel();
            loginView.Show();
            AddView(loginView, null);
        }

        private void LoginViewModelOnOnLogIn(TypeView typeView, User user)
        {
            switch (typeView)
            {
                case TypeView.OrderView:
                    {
                        orderView = new OrderView();
                        orderView.DataContext = new OrderViewModel(CreateViewAction, user);
                        loginView.Close();
                        orderView.Show();
                        AddView(orderView, loginView);
                        OrderViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
                case TypeView.AdminView:
                    {
                        adminView = new AdminView();
                        adminView.DataContext = new AdminViewModel(CreateViewAction, user);
                        loginView.Close();
                        adminView.Show();
                        AddView(adminView, loginView);
                        AdminViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
            }
        }

        private void MethodOnLogOut(object sender, TypeView typeView)
        {
            OrderViewModel.OnLogOut -= MethodOnLogOut;
            AdminViewModel.OnLogOut -= MethodOnLogOut;

            loginView = new LoginView();
            loginView.DataContext = new LoginViewModel();
            CloseAllView();
            AddView(loginView, null);
            loginView.Show();
        }

        public static void CloseViewAction(TypeView typeView)
        {
            Application.Current.MainWindow.Close();
        }

        public static IView CreateViewAction(object o, TypeView typeView)
        {
            IView view;

            switch (typeView)
            {
                case TypeView.AddUserView:
                    {
                        view = new AddUserView(new AddUserViewModel());
                        view.ShowView();
                        break;
                    }

                case TypeView.AddFoodView:
                    {
                        view = new AddFoodView(new AddFoodViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.AddDrinkView:
                    {
                        view = new AddDrinkView(new AddDrinkViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.AddModificatorView:
                    {
                        view = new AddModificatorView(new AddModificatorViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.EditUserView:
                    {
                        view = new EditUserView(new EditUserViewModel((User)o));
                        view.ShowView();
                        break;
                    }
                case TypeView.EditFoodView:
                    {
                        view = new EditFoodView(new EditFoodViewModel((Food)o));
                        view.ShowView();
                        break;
                    }
                case TypeView.EditDrinkView:
                    {
                        view = new EditDrinkView(new EditDrinkViewModel((Drink)o));
                        view.ShowView();
                        break;
                    }
                case TypeView.EditModificatorView:
                    {
                        view = new EditModificatorView(new EditModificatorViewModel((Modificator)o));
                        view.ShowView();
                        break;
                    }
                case TypeView.MakeOrderView:
                    {
                        view = new MakeOrderView(new MakeOrderViewModel(CreateViewAction));
                        view.ShowView();
                        break;
                    }
                case TypeView.HistoryView:
                    {
                        view = new HistoryView(new HistoryViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.ColdDrinkListView:
                    {
                        view = new ColdDrinkListView(new ColdDrinkListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.DessertListView:
                    {
                        view = new DessertListView(new DessertListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.FishListView:
                    {
                        view = new FishListView(new FishListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.GarnishListView:
                    {
                        view = new GarnishListView(new GarnishListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.HotDrinkListView:
                    {
                        view = new HotDrinkListView(new HotDrinkListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.JuiceListView:
                    {
                        view = new JuiceListView(new JuiceListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.MealListView:
                    {
                        view = new MealListView(new MealListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.MeatDishListView:
                    {
                        view = new MeatDishListView(new MeatDishListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.PastaListView:
                    {
                        view = new PastaListView(new PastaListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.PizzaListView:
                    {
                        view = new PizzaListView(new PizzaListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.SaladListView:
                    {
                        view = new SaladListView(new SaladListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.SauceListView:
                    {
                        view = new SauceListView(new SauceListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.SnackListView:
                    {
                        view = new SnackListView(new SnackListViewModel());
                        view.ShowView();
                        break;
                    }
                case TypeView.SoupListView:
                    {
                        view = new SoupListView(new SoupListViewModel());
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

        public void CloseAllView()
        {
            foreach (var view in ViewList)
            {
                view.Close();
            }

            ViewList.Clear();
        }

        public void KillAllView()
        {
            Application.Current.Shutdown();
        }

        public void AddView(Window view1,Window view2)
        {
            ViewList.Add(view1);
            ViewList.Remove(view2);
        }
    }

}
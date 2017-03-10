using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using DataBaseService.Interface;
using DataBaseService.Model;
using Shared.Enum;
using ViewModel;
using ViewModel.AdditionalViewModel;
using ViewModel.MainViewModel;
using WPF_Project.View;

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

        public void StartLoginView()
        {
            LoginViewModel.OnLogIn += LoginViewModelOnOnLogIn;
            loginView = new LoginView();
            loginView.DataContext = new LoginViewModel();
            loginView.Show();
            AddView(loginView, null);
        }

        private void LoginViewModelOnOnLogIn(TypeView typeView, string s)
        {
            switch (typeView)
            {
                case TypeView.OrderView:
                    {
                        orderView = new OrderView();
                        orderView.DataContext = new OrderViewModel(CreateViewAction, s);
                        loginView.Close();
                        orderView.Show();
                        AddView(orderView, loginView);
                        OrderViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
                case TypeView.AdminView:
                    {
                        adminView = new AdminView();
                        adminView.DataContext = new AdminViewModel(CreateViewAction, s);
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
                        view = new MakeOrderView(new MakeOrderViewModel());
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
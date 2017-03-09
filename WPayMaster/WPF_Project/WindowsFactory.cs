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
                        orderView.DataContext = new OrderViewModel(s);
                        loginView.Close();
                        orderView.Show();
                        AddView(orderView, loginView);
                        OrderViewModel.OnLogOut += MethodOnLogOut;
                        break;
                    }
                case TypeView.AdminView:
                    {
                        adminView = new AdminView();
                        adminView.DataContext = new AdminViewModel(s, CreateViewAction);
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
            IView viewEmpty;

            switch (typeView)
            {
                case TypeView.AddUserView:
                    {
                        viewEmpty = new AddUserView(new AddUserViewModel());
                        viewEmpty.ShowView();
                        break;
                    }

                case TypeView.AddFoodView:
                    {
                        viewEmpty = new AddFoodView(new AddFoodViewModel());
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.AddDrinkView:
                    {
                        viewEmpty = new AddDrinkView(new AddDrinkViewModel());
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.AddModificatorView:
                    {
                        viewEmpty = new AddModificatorView(new AddModificatorViewModel());
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.EditUserView:
                    {
                        viewEmpty = new EditUserView(new EditUserViewModel((User)o));
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.EditFoodView:
                    {
                        viewEmpty = new EditFoodView(new EditFoodViewModel((Food)o));
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.EditDrinkView:
                    {
                        viewEmpty = new EditDrinkView(new EditDrinkViewModel((Drink)o));
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.EditModificatorView:
                    {
                        viewEmpty = new EditModificatorView(new EditModificatorViewModel((Modificator)o));
                        viewEmpty.ShowView();
                        break;
                    }
                case TypeView.MakeOrderView:
                    {
                        viewEmpty = new MakeOrderView();
                        break;
                    }
                default:
                    {
                        viewEmpty = null;
                        break;
                    }
            }

            return viewEmpty;
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
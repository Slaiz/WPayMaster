using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using Shared.Enum;
using ViewModel;
using WPF_Project.View;

namespace WPF_Project
{
    public class WindowsFactory
    {
        private LoginViewModel loginViewModel;
        private LoginView loginView;
        private List<Window> ViewList = new List<Window>(); 

        public WindowsFactory()
        {

        }

        public void StartLoginView()
        {
            loginViewModel = new LoginViewModel();
            LoginViewModel.OnLogIn += LoginViewModel_OnLogIn;
            loginView = new LoginView();
            loginView.DataContext = loginViewModel;
            loginView.Show();
            AddView(loginView, null);
        }

        private void LoginViewModel_OnLogIn(object sender, TypeView e)
        {
            switch (e)
            {
                case TypeView.OrderView:
                    {
                        OrderView orderView = new OrderView();
                        orderView.DataContext = new OrderViewModel();
                        loginView.Close();
                        orderView.Show();
                        AddView(orderView, loginView);
                        OrderViewModel.OnLogOut+=MethodOnLogOut;
                        break;
                    }
                case TypeView.AdminView:
                {
                        AdminView adminView = new AdminView();
                        adminView.DataContext = new AdminViewModel();
                        loginView.Close();
                        adminView.Show();
                        AddView(adminView,loginView);
                        AdminViewModel.OnLogOut += MethodOnLogOut;
                        break;
                }
                default:
                    break;
            }
        }

        private void MethodOnLogOut(object sender, TypeView typeView)
        {
            loginViewModel = new LoginViewModel();
            loginView = new LoginView();
            loginView.DataContext = loginViewModel;
            CloseAllView();
            loginView.Show();
        }

        public void CloseAllView()
        {
            foreach (var view in ViewList)
            {
                view.Close();
            }
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
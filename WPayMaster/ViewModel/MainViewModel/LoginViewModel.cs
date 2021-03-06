﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DataBaseService;
using DataBaseService.Context;
using PropertyChanged;
using Shared;
using Shared.Enums;
using Shared.Interface;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class LoginViewModel
    {
        public static event Action<ViewType, User> OnLogIn;
        public static event Action OnCloseView;

        public DbService DbService = new DbService();

        public ICommand ExitCommand { get; set; }
        public ICommand ChangeColorCommand { get; set; }
        public ICommand LogInCommand { get; set; }

        public Func<object, ViewType, IView> CreateViewAction { get; set; }

        private ObservableCollection<User> UserList { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public Brush BackroundBrushColor { get; set; }
        public static Brush ThemeBrushColor { get; set; }

        private Color[] Colors = new Color[]
        {
            Color.FromRgb(33, 150, 243), Color.FromRgb(29, 233, 182), Color.FromRgb(233, 30, 99),
            Color.FromRgb(255, 152, 0), Color.FromRgb(255, 87, 34),Color.FromRgb(96, 125, 139),
            Color.FromRgb(213, 0, 0), Color.FromRgb(103, 58, 183)
        };

        public LoginViewModel(Func<object, ViewType, IView> createViewAction)
        {

            CreateViewAction = createViewAction;
            UserList = new ObservableCollection<User>(DbService.GetUsersList());

            BackroundBrushColor = ThemeBrushColor;

            ExitCommand = new Command(arg => Exit());
            ChangeColorCommand = new Command(arg => ChangeColor());
            LogInCommand = new Command(arg => LogIn());
        }

        private void ChangeColor()
        {
            Random r = new Random();

            BackroundBrushColor = new SolidColorBrush(Colors[r.Next(1,8)]);

            ThemeBrushColor = BackroundBrushColor;
        }

        private void Exit()
        {
            CreateViewAction(null, ViewType.LoginView);
        }

        private void LogIn()
        {
            if (Login != null && Password != null)
            {
                foreach (var user in UserList)
                {                    
                    if (user.UserName.Contains(Login) && user.Password.Contains(Password))
                    {
                        if (user.Post.Contains("Адміністратор"))
                        {
                            DoOnLogIn(ViewType.AdminView, user);
                            //DbService.WriteStory(user, @"Увійшов в програму");
                        }
                        else
                        {
                            DoOnLogIn(ViewType.CashierView, user);
                            //DbService.WriteStory(user, @"Увійшов в програму");
                        }
                        return;
                    }
                }

                MessageBox.Show("Ви ввели неправильний логін або пароль", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Введіть будь ласка логін і пароль", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private static void DoOnLogIn(ViewType arg1, User user)
        {
            OnLogIn?.Invoke(arg1, user);
        }

        public static void DoOnCloseView()
        {
            OnCloseView?.Invoke();
        }
    }
}
﻿using System;
using System.Linq.Expressions;
using System.Windows.Input;
using Shared.Command;
using Shared.Enum;

namespace WPF_Project.ViewModel
{
    public class OrderViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;
        public ICommand LogOutCommand { get; set; }

        public OrderViewModel()
        {
            LogOutCommand = new MainCommand(arg =>LogOut());
        }

        private void LogOut()
        {
            DoOnLogOut(TypeView.OrderView);
        }

        private static void DoOnLogOut(TypeView e)
        {
            OnLogOut?.Invoke(null, e);
        }
    }
}
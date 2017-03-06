using System;
using System.Windows.Input;
using Shared.Command;
using Shared.Enum;

namespace ViewModel
{
    public class AdminViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;
        public ICommand LogOutCommand { get; set; }

        public AdminViewModel()
        {
            LogOutCommand = new MainCommand(arg =>LogOut());
        }

        private void LogOut()
        {
            DoOnLogOut(TypeView.AdminView);
        }

        private static void DoOnLogOut(TypeView e)
        {
            OnLogOut?.Invoke(null, e);
        }
    }
}
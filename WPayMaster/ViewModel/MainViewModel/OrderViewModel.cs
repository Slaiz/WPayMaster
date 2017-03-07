using System;
using System.Windows.Input;
using PropertyChanged;
using Shared;
using Shared.Enum;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class OrderViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;
        public ICommand LogOutCommand { get; set; }

        public OrderViewModel()
        {
            LogOutCommand = new CommandHandler(arg =>LogOut());
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
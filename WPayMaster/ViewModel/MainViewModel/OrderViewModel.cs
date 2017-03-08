using System;
using System.Windows.Input;
using System.Windows.Threading;
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

        public string NameCashier { get; set; }
        public DateTime CurrentTime { get; set; }

        public OrderViewModel(string nameCashier)
        {
            NameCashier = nameCashier;
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1),
            DispatcherPriority.Normal,
            delegate
            {
                CurrentTime = DateTime.Now;
            },
            Dispatcher.CurrentDispatcher);

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
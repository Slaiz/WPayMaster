using System;
using System.Windows.Input;
using System.Windows.Threading;
using DataBaseService.Interface;
using PropertyChanged;
using Shared;
using Shared.Enum;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class OrderViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;
        public Func<object, TypeView, IView> CreateViewAction { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenMakeOrderViewCommand { get; set; }

        public string NameCashier { get; set; }
        public DateTime CurrentTime { get; set; }

        public OrderViewModel(Func<object, TypeView, IView>  createViewAction,string nameCashier)
        {
            CreateViewAction = createViewAction;

            NameCashier = nameCashier;

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1),
            DispatcherPriority.Normal,
            delegate
            {
                CurrentTime = DateTime.Now;
            },
            Dispatcher.CurrentDispatcher);

            LogOutCommand = new CommandHandler(arg =>LogOut());
            OpenMakeOrderViewCommand = new CommandHandler(arg => OpenMakeOrderView());
        }

        private void OpenMakeOrderView()
        {
            CreateViewAction.Invoke(null, TypeView.MakeOrderView);
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
using System;
using System.Windows.Input;
using System.Windows.Threading;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using Shared.Interface;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class OrderViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public ICommand LogOutCommand { get; set; }
        public ICommand StartWorkCommand { get; set; }
        public ICommand StopWorkCommand { get; set; }
        public ICommand OpenMakeOrderViewCommand { get; set; }

        public DbService DbService = new DbService();

        public User Cashier { get; set; }
        public string CashierName { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime StartWorkTime { get; set; }

        public OrderViewModel(Func<object, TypeView, IView> createViewAction, User user)
        {
            CreateViewAction = createViewAction;

            Cashier = user;
            CashierName = user.UserName + " " + user.Surname;

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1),
            DispatcherPriority.Normal,
            delegate
            {
                CurrentTime = DateTime.Now;
            },
            Dispatcher.CurrentDispatcher);

            LogOutCommand = new CommandHandler(arg => LogOut());
            StartWorkCommand = new CommandHandler(arg => StartWork());
            StopWorkCommand = new CommandHandler(arg => StopWork());
            OpenMakeOrderViewCommand = new CommandHandler(arg => OpenMakeOrderView());
        }

        private void StartWork()
        {
            StartWorkTime = DateTime.Now;
        }

        private void StopWork()
        {
            DbService.AddWorkingTime(Cashier, CurrentTime - StartWorkTime);
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
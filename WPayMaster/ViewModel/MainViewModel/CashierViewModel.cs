using System;
using System.Windows.Input;
using System.Windows.Media;
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
    public class CashierViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;
        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        #region Command
        public ICommand LogOutCommand { get; set; }
        public ICommand StartWorkCommand { get; set; }
        public ICommand StopWorkCommand { get; set; }
        public ICommand ChangeColorCommand { get; set; }
        public ICommand OpenCheckHistoryViewCommand { get; set; }
        public ICommand OpenColdDrinkListViewCommand { get; set; }
        public ICommand OpenDessertListViewCommand { get; set; }
        public ICommand OpenFishListViewCommand { get; set; }
        public ICommand OpenGarnishListViewCommand { get; set; }
        public ICommand OpenHotDrinkListViewCommand { get; set; }
        public ICommand OpenJuiceListViewCommand { get; set; }
        public ICommand OpenMealListViewCommand { get; set; }
        public ICommand OpenMeatDishListViewCommand { get; set; }
        public ICommand OpenPastaListViewCommand { get; set; }
        public ICommand OpenPizzaListViewCommand { get; set; }
        public ICommand OpenSaladListViewCommand { get; set; }
        public ICommand OpenSauceListViewCommand { get; set; }
        public ICommand OpenSnackListViewCommand { get; set; }
        public ICommand OpenSoupListViewCommand { get; set; }
        #endregion

        public DbService DbService = new DbService();

        public User Cashier { get; set; }
        public string CashierName { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime StartWorkTime { get; set; }
        public Brush PanelBrushColor { get; set; }

        private Color[] Colors = new Color[]
        {
            Color.FromRgb(33, 150, 243), Color.FromRgb(29, 233, 182), Color.FromRgb(233, 30, 99),
            Color.FromRgb(255, 152, 0), Color.FromRgb(255, 87, 34),Color.FromRgb(96, 125, 139),
            Color.FromRgb(213, 0, 0), Color.FromRgb(103, 58, 183)
        };

        public CashierViewModel(Func<object, TypeView, IView> createViewAction, User user)
        {
            CreateViewAction = createViewAction;

            PanelBrushColor = LoginViewModel.ThemeBrushColor;

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
            ChangeColorCommand = new CommandHandler(arg => ChangeColor());
            OpenCheckHistoryViewCommand = new CommandHandler(arg => OpenCheckHistoryView());

            OpenColdDrinkListViewCommand = new CommandHandler(arg => OpenColdDrinkListView());
            OpenDessertListViewCommand = new CommandHandler(arg => OpenDessertListView());
            OpenFishListViewCommand = new CommandHandler(arg => OpenFishListView());
            OpenGarnishListViewCommand = new CommandHandler(arg => OpenGarnishListView());
            OpenHotDrinkListViewCommand = new CommandHandler(arg => OpenHotDrinkListView());
            OpenJuiceListViewCommand = new CommandHandler(arg => OpenJuiceListView());
            OpenMealListViewCommand = new CommandHandler(arg => OpenMealListView());
            OpenMeatDishListViewCommand = new CommandHandler(arg => OpenMeatDishListView());
            OpenPastaListViewCommand = new CommandHandler(arg => OpenPastaListView());
            OpenPizzaListViewCommand = new CommandHandler(arg => OpenPizzaListView());
            OpenSaladListViewCommand = new CommandHandler(arg => OpenSaladListView());
            OpenSauceListViewCommand = new CommandHandler(arg => OpenSauceListView());
            OpenSnackListViewCommand = new CommandHandler(arg => OpenSnackListView());
            OpenSoupListViewCommand = new CommandHandler(arg => OpenSoupListView());
        }

        private void ChangeColor()
        {
            Random r = new Random();

            PanelBrushColor = new SolidColorBrush(Colors[r.Next(1, 8)]);

            LoginViewModel.ThemeBrushColor = PanelBrushColor;
        }

        private void LogOut()
        {
            DoOnLogOut(TypeView.CashierView);
        }

        private void StartWork()
        {
            StartWorkTime = DateTime.Now;
        }

        private void StopWork()
        {
            DbService.AddWorkingTime(Cashier, CurrentTime - StartWorkTime);
        }

        private void OpenCheckHistoryView()
        {
            throw new NotImplementedException();
        }

        #region MethodOpenItemListView
        private static void DoOnLogOut(TypeView e)
        {
            OnLogOut?.Invoke(null, e);
        }

        private void OpenSnackListView()
        {
            CreateViewAction.Invoke(null, TypeView.SnackListView);
        }

        private void OpenSauceListView()
        {
            CreateViewAction.Invoke(null, TypeView.SauceListView);
        }

        private void OpenSaladListView()
        {
            CreateViewAction.Invoke(null, TypeView.SaladListView);
        }

        private void OpenPizzaListView()
        {
            CreateViewAction.Invoke(null, TypeView.PizzaListView);
        }

        private void OpenPastaListView()
        {
            CreateViewAction.Invoke(null, TypeView.PastaListView);
        }

        private void OpenMeatDishListView()
        {
            CreateViewAction.Invoke(null, TypeView.MeatDishListView);
        }

        private void OpenMealListView()
        {
            CreateViewAction.Invoke(null, TypeView.MealListView);
        }

        private void OpenJuiceListView()
        {
            CreateViewAction.Invoke(null, TypeView.JuiceListView);
        }

        private void OpenHotDrinkListView()
        {
            CreateViewAction.Invoke(null, TypeView.HotDrinkListView);
        }

        private void OpenGarnishListView()
        {
            CreateViewAction.Invoke(null, TypeView.GarnishListView);
        }

        private void OpenFishListView()
        {
            CreateViewAction.Invoke(null, TypeView.FishListView);
        }

        private void OpenDessertListView()
        {
            CreateViewAction.Invoke(null, TypeView.DessertListView);
        }

        private void OpenColdDrinkListView()
        {
            CreateViewAction.Invoke(null, TypeView.ColdDrinkListView);
        }

        private void OpenSoupListView()
        {
            CreateViewAction.Invoke(null, TypeView.SoupListView);
        }
        #endregion
    }
}
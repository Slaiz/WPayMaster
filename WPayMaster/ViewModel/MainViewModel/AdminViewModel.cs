using System;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.UserControlViewModel;
using WPF_Project.View.UserControl;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class AdminViewModel
    {
        public static event EventHandler<TypeView> OnLogOut;
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenUserUserControlCommand { get; set; }
        public ICommand OpenFoodUserControlCommand { get; set; }
        public ICommand OpenDrinkUserControlCommand { get; set; }
        public ICommand OpenModificatorUserControlCommand { get; set; }
        public ICommand OpenAddItemViewCommand { get; set; }
        public ICommand OpenEditItemViewCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }

        public UserViewModel userViewModel;
        public FoodViewModel foodViewModel;
        public DrinkViewModel drinkViewModel;
        public ModificatorViewModel modificatorViewModel;

        public string NameAdmin { get; set; }
        public DateTime CurrentTime { get; set; }

        public UserControl CurrentUserControl { get; set; }

        public AdminViewModel(string nameAdmin)
        {
            NameAdmin = nameAdmin;

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1),
            DispatcherPriority.Normal,
            delegate
            {
                 CurrentTime = DateTime.Now;
            }, 
            Dispatcher.CurrentDispatcher );

            OpenUserControl(TypeUserControl.UserUserControl);

            LogOutCommand = new CommandHandler(arg => LogOut());
            OpenUserUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.UserUserControl));
            OpenFoodUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.FoodUserControl));
            OpenDrinkUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.DrinkUserControl));
            OpenModificatorUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.ModificatorUserControl));
            OpenAddItemViewCommand = new CommandHandler(arg => OpenAddUserView());
            OpenEditItemViewCommand = new CommandHandler(arg => OpenEditItemView());
            DeleteItemCommand = new CommandHandler(arg => DeleteItem());
        }

        private void OpenAddUserView()
        {
            throw new NotImplementedException();
        }

        private void OpenEditItemView()
        {
            throw new NotImplementedException();
        }

        private void DeleteItem()
        {
            throw new NotImplementedException();
        }

        private void OpenUserControl(TypeUserControl typeUserControl)
        {
            switch (typeUserControl)
            {
                case TypeUserControl.UserUserControl:
                    {
                        CurrentUserControl = new UserUserControl();
                        userViewModel = new UserViewModel();
                        CurrentUserControl.DataContext = userViewModel;
                        break;
                    }
                case TypeUserControl.FoodUserControl:
                    {
                        CurrentUserControl = new FoodUserControl();
                        foodViewModel = new FoodViewModel();
                        CurrentUserControl.DataContext = foodViewModel;
                        break;
                    }
                case TypeUserControl.DrinkUserControl:
                    {
                        CurrentUserControl = new DrinkUserControl();
                        drinkViewModel = new DrinkViewModel();
                        CurrentUserControl.DataContext = drinkViewModel;
                        break;
                    }
                case TypeUserControl.ModificatorUserControl:
                    {
                        CurrentUserControl = new ModificatorUserControl();
                        modificatorViewModel = new ModificatorViewModel();
                        CurrentUserControl.DataContext = modificatorViewModel;
                        break;
                    }
            }
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
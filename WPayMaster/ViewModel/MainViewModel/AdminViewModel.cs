using System;
using System.Windows.Controls;
using System.Windows.Input;
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

        public UserViewModel userViewModel;
        public FoodViewModel foodViewModel;
        public DrinkViewModel drinkViewModel;
        public ModificatorViewModel modificatorViewModel;

        public UserControl CurrentUserControl { get; set; }

        public AdminViewModel()
        {
            OpenUserControl(TypeUserControl.UserUserControl);

            LogOutCommand = new CommandHandler(arg =>LogOut());
            OpenUserUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.UserUserControl));
            OpenFoodUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.FoodUserControl));
            OpenDrinkUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.DrinkUserControl));
            OpenModificatorUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.ModificatorUserControl));
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
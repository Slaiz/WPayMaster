using System;
using System.Windows.Controls;
using System.Windows.Input;
using PropertyChanged;
using Shared;
using Shared.Enum;
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

        public UserControl CurrentUserControl { get; set; }

        public AdminViewModel()
        {
            CurrentUserControl = new UserUserControl();

            LogOutCommand = new CommandHandler(arg =>LogOut());
            OpenUserUserControlCommand = new CommandHandler(arg => OpenUserControl(1));
            OpenFoodUserControlCommand = new CommandHandler(arg => OpenUserControl(2));
            OpenDrinkUserControlCommand = new CommandHandler(arg => OpenUserControl(3));
            OpenModificatorUserControlCommand = new CommandHandler(arg => OpenUserControl(4));
        }

        private void OpenUserControl(int k)
        {
            switch (k)
            {
                case 1:
                {
                    CurrentUserControl = new UserUserControl();
                    break;
                }
                case 2:
                {
                    CurrentUserControl = new FoodUserControl();
                    break;
                }
                case 3:
                {
                    CurrentUserControl = new DrinkUserControl();
                    break;
                }
                case 4:
                {
                    CurrentUserControl = new ModificatorUserControl();
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
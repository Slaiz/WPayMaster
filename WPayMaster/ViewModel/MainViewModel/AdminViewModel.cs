using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using Shared.Interface;
using ViewModel.UserControlViewModel;
using UserControl;

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

        private UserViewModel userViewModel;
        private FoodViewModel foodViewModel;
        private DrinkViewModel drinkViewModel;
        private ModificatorViewModel modificatorViewModel;

        public DbService DbService = new DbService();

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public Visibility UserTextBoxVisibility { get; set; }
        public Visibility FoodTextBoxVisibility { get; set; }
        public Visibility DrinkTextBoxVisibility { get; set; }
        public Visibility ModificatorTextBoxVisibility { get; set; }
        public string AdminName { get; set; }
        public DateTime CurrentTime { get; set; }
        public object SelectedItem { get; set; }

        public System.Windows.Controls.UserControl CurrentUserControl { get; set; }
        private TypeView TypeAddViewItem { get; set; }
        private TypeView TypeEditViewItem { get; set; }

        public AdminViewModel(Func<object, TypeView, IView> createViewAction, User user)
        {
            CreateViewAction = createViewAction;

            UserTextBoxVisibility = Visibility.Visible;

            AdminName = user.UserName + " " + user.Surname;

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1),
            DispatcherPriority.Normal,
            delegate
            {
                CurrentTime = DateTime.Now;
            },
            Dispatcher.CurrentDispatcher);

            OpenUserControl(TypeUserControl.UserUserControl);

            LogOutCommand = new CommandHandler(arg => LogOut());
            OpenUserUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.UserUserControl));
            OpenFoodUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.FoodUserControl));
            OpenDrinkUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.DrinkUserControl));
            OpenModificatorUserControlCommand = new CommandHandler(arg => OpenUserControl(TypeUserControl.ModificatorUserControl));

            OpenAddItemViewCommand = new CommandHandler(arg => OpenAddItemView());
            OpenEditItemViewCommand = new CommandHandler(arg => OpenEditItemView());
            DeleteItemCommand = new CommandHandler(arg => DeleteItem());
        }

        private void OpenAddItemView()
        {
            CreateViewAction.Invoke(null, TypeAddViewItem);
        }

        private void OpenEditItemView()
        {
            switch (TypeEditViewItem)
            {
                case TypeView.EditUserView:
                    {
                        if (UserViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(UserViewModel.SelectedItem, TypeEditViewItem);
                            UserViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть користувача", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case TypeView.EditFoodView:
                    {
                        if (FoodViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(FoodViewModel.SelectedItem, TypeEditViewItem);
                            FoodViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть їжу", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case TypeView.EditDrinkView:
                    {
                        if (DrinkViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(DrinkViewModel.SelectedItem, TypeEditViewItem);
                            DrinkViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть напиток", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case TypeView.EditModificatorView:
                    {
                        if (ModificatorViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(ModificatorViewModel.SelectedItem, TypeEditViewItem);
                            ModificatorViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть додаткове", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
            }
        }

        private void DeleteItem()
        {
            switch (TypeEditViewItem)
            {
                case TypeView.EditUserView:
                    {
                        if (UserViewModel.SelectedItem != null)
                        {
                            var selectedItem = UserViewModel.SelectedItem;
                            DbService.DeleteUser(selectedItem);
                            UserViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть користувача", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case TypeView.EditFoodView:
                    {
                        if (FoodViewModel.SelectedItem != null)
                        {
                            SelectedItem = FoodViewModel.SelectedItem;
                            DbService.DeleteFood((Food)SelectedItem);
                            FoodViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть їжу", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case TypeView.EditDrinkView:
                    {
                        if (DrinkViewModel.SelectedItem != null)
                        {
                            SelectedItem = DrinkViewModel.SelectedItem;
                            DbService.DeleteDrink((Drink)SelectedItem);
                            DrinkViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть напиток", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case TypeView.EditModificatorView:
                    {
                        if (ModificatorViewModel.SelectedItem != null)
                        {
                            SelectedItem = ModificatorViewModel.SelectedItem;
                            DbService.DeleteModificator((Modificator)SelectedItem);
                            ModificatorViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть додаткове", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
            }

            MessageBox.Show("Запис видалено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        TypeAddViewItem = TypeView.AddUserView;
                        TypeEditViewItem = TypeView.EditUserView;
                        UserTextBoxVisibility = Visibility.Visible;
                        FoodTextBoxVisibility = Visibility.Hidden;
                        DrinkTextBoxVisibility = Visibility.Hidden;
                        ModificatorTextBoxVisibility = Visibility.Hidden;
                        break;
                    }
                case TypeUserControl.FoodUserControl:
                    {
                        CurrentUserControl = new FoodUserControl();
                        foodViewModel = new FoodViewModel();
                        CurrentUserControl.DataContext = foodViewModel;
                        TypeAddViewItem = TypeView.AddFoodView;
                        TypeEditViewItem = TypeView.EditFoodView;
                        UserTextBoxVisibility = Visibility.Hidden;
                        FoodTextBoxVisibility = Visibility.Visible;
                        DrinkTextBoxVisibility = Visibility.Hidden;
                        ModificatorTextBoxVisibility = Visibility.Hidden;
                        break;
                    }
                case TypeUserControl.DrinkUserControl:
                    {
                        CurrentUserControl = new DrinkUserControl();
                        drinkViewModel = new DrinkViewModel();
                        CurrentUserControl.DataContext = drinkViewModel;
                        TypeAddViewItem = TypeView.AddDrinkView;
                        TypeEditViewItem = TypeView.EditDrinkView;
                        UserTextBoxVisibility = Visibility.Hidden;
                        FoodTextBoxVisibility = Visibility.Hidden;
                        DrinkTextBoxVisibility = Visibility.Visible;
                        ModificatorTextBoxVisibility = Visibility.Hidden;
                        break;
                    }
                case TypeUserControl.ModificatorUserControl:
                    {
                        CurrentUserControl = new ModificatorUserControl();
                        modificatorViewModel = new ModificatorViewModel();
                        CurrentUserControl.DataContext = modificatorViewModel;
                        TypeAddViewItem = TypeView.AddModificatorView;
                        TypeEditViewItem = TypeView.EditModificatorView;
                        UserTextBoxVisibility = Visibility.Hidden;
                        FoodTextBoxVisibility = Visibility.Hidden;
                        DrinkTextBoxVisibility = Visibility.Hidden;
                        ModificatorTextBoxVisibility = Visibility.Visible;
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
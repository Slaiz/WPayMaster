using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using DataBaseService;
using DataBaseService.Context;
using PropertyChanged;
using Shared;
using Shared.Enums;
using Shared.Interface;
using ViewModel.UserControlViewModel;
using UserControl;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class AdminViewModel
    {
        public static event EventHandler<ViewType> OnLogOut;

        #region Commands
        public ICommand ChangeColorCommand { get; set; }
        public ICommand OpenHistoryViewCommand { get; set; }
        public ICommand OpenStatisticViewCommand { get; set; }
        public ICommand OpenCheckHistoryViewCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenUserUserControlCommand { get; set; }
        public ICommand OpenFoodUserControlCommand { get; set; }
        public ICommand OpenDrinkUserControlCommand { get; set; }
        public ICommand OpenModificatorUserControlCommand { get; set; }
        public ICommand OpenAddItemViewCommand { get; set; }
        public ICommand OpenEditItemViewCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand OpenPreviewItemCommand { get; set; }
        #endregion


        private UserViewModel userViewModel;
        private FoodViewModel foodViewModel;
        private DrinkViewModel drinkViewModel;
        private ModificatorViewModel modificatorViewModel;

        public DbService DbService = new DbService();

        public Func<object, ViewType, IView> CreateViewAction { get; set; }

        public Visibility UserTextBoxVisibility { get; set; }
        public Visibility FoodTextBoxVisibility { get; set; }
        public Visibility DrinkTextBoxVisibility { get; set; }
        public Visibility ModificatorTextBoxVisibility { get; set; }
        public string AdminName { get; set; }
        public DateTime CurrentTime { get; set; }
        public object SelectedItem { get; set; }
        public Brush PanelBrushColor { get; set; }

        private Color[] Colors = new Color[]
        {
            Color.FromRgb(33, 150, 243), Color.FromRgb(29, 233, 182), Color.FromRgb(233, 30, 99),
            Color.FromRgb(255, 152, 0), Color.FromRgb(255, 87, 34),Color.FromRgb(96, 125, 139),
            Color.FromRgb(213, 0, 0), Color.FromRgb(103, 58, 183)
        };

        public System.Windows.Controls.UserControl CurrentUserControl { get; set; }
        private ViewType ViewTypeAddItem { get; set; }
        private ViewType ViewTypeEditItem { get; set; }

        public AdminViewModel(Func<object, ViewType, IView> createViewAction, User user)
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

            //DbService.WriteStory();

            PanelBrushColor = LoginViewModel.ThemeBrushColor;

            OpenUserControl(UserControlType.UserUserControl);

            ChangeColorCommand = new Command(arg => ChangeColor());
            OpenHistoryViewCommand = new Command(arg => OpenHistoryView());
            OpenStatisticViewCommand = new Command(arg => OpenStatisticView());
            OpenCheckHistoryViewCommand = new Command(arg => OpenCheckHistoryView());
            LogOutCommand = new Command(arg => LogOut());
            OpenUserUserControlCommand = new Command(arg => OpenUserControl(UserControlType.UserUserControl));
            OpenFoodUserControlCommand = new Command(arg => OpenUserControl(UserControlType.FoodUserControl));
            OpenDrinkUserControlCommand = new Command(arg => OpenUserControl(UserControlType.DrinkUserControl));
            OpenModificatorUserControlCommand = new Command(arg => OpenUserControl(UserControlType.ModificatorUserControl));

            OpenAddItemViewCommand = new Command(arg => OpenAddItemView());
            OpenEditItemViewCommand = new Command(arg => OpenEditItemView());
            DeleteItemCommand = new Command(arg => DeleteItem());
            OpenPreviewItemCommand = new Command(arg => OpenPreviewItem());
        }

        private void OpenCheckHistoryView()
        {
            CreateViewAction.Invoke(null, ViewType.CheckHistoryView);
        }

        private void OpenStatisticView()
        {
            CreateViewAction.Invoke(null, ViewType.StatisticView);
        }

        private void OpenPreviewItem()
        {
            switch (ViewTypeEditItem)
            {
                case ViewType.EditUserView:
                {
                    if (UserViewModel.SelectedItem != null)
                    {
                        CreateViewAction.Invoke(UserViewModel.SelectedItem, ViewType.PreviewUserView);
                        UserViewModel.SelectedItem = null;
                    }
                    else MessageBox.Show("Будь ласка виберіть користувача", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                case ViewType.EditFoodView:
                {
                    if (FoodViewModel.SelectedItem != null)
                    {
                        CreateViewAction.Invoke(FoodViewModel.SelectedItem, ViewType.PreviewFoodView);
                        FoodViewModel.SelectedItem = null;
                    }
                    else MessageBox.Show("Будь ласка виберіть їжу", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                case ViewType.EditDrinkView:
                {
                    if (DrinkViewModel.SelectedItem != null)
                    {
                        CreateViewAction.Invoke(DrinkViewModel.SelectedItem, ViewType.PreviewDrinkView);
                        DrinkViewModel.SelectedItem = null;
                    }
                    else MessageBox.Show("Будь ласка виберіть напиток", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                case ViewType.EditModificatorView:
                {
                    if (ModificatorViewModel.SelectedItem != null)
                    {
                        CreateViewAction.Invoke(ModificatorViewModel.SelectedItem, ViewType.PreviewModificatorView);
                        ModificatorViewModel.SelectedItem = null;
                    }
                    else MessageBox.Show("Будь ласка виберіть додаткове", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
        }

        private void ChangeColor()
        {
            Random r = new Random();

            PanelBrushColor = new SolidColorBrush(Colors[r.Next(1, 8)]);

            LoginViewModel.ThemeBrushColor = PanelBrushColor;
        }

        private void OpenHistoryView()
        {
            CreateViewAction.Invoke(null, ViewType.ActivityHistoryView);
        }

        private void OpenAddItemView()
        {
            CreateViewAction.Invoke(null, ViewTypeAddItem);
        }

        private void OpenEditItemView()
        {
            switch (ViewTypeEditItem)
            {
                case ViewType.EditUserView:
                    {
                        if (UserViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(UserViewModel.SelectedItem, ViewTypeEditItem);
                            UserViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть користувача", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case ViewType.EditFoodView:
                    {
                        if (FoodViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(FoodViewModel.SelectedItem, ViewTypeEditItem);
                            FoodViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть їжу", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case ViewType.EditDrinkView:
                    {
                        if (DrinkViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(DrinkViewModel.SelectedItem, ViewTypeEditItem);
                            DrinkViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть напиток", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                case ViewType.EditModificatorView:
                    {
                        if (ModificatorViewModel.SelectedItem != null)
                        {
                            CreateViewAction.Invoke(ModificatorViewModel.SelectedItem, ViewTypeEditItem);
                            ModificatorViewModel.SelectedItem = null;
                        }
                        else MessageBox.Show("Будь ласка виберіть додаткове", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
            }
        }

        private void DeleteItem()
        {
            switch (ViewTypeEditItem)
            {
                case ViewType.EditUserView:
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
                case ViewType.EditFoodView:
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
                case ViewType.EditDrinkView:
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
                case ViewType.EditModificatorView:
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

        private void OpenUserControl(UserControlType userControlType)
        {
            switch (userControlType)
            {
                case UserControlType.UserUserControl:
                    {
                        CurrentUserControl = new UserUserControl();
                        userViewModel = new UserViewModel();
                        CurrentUserControl.DataContext = userViewModel;
                        ViewTypeAddItem = ViewType.AddUserView;
                        ViewTypeEditItem = ViewType.EditUserView;
                        UserTextBoxVisibility = Visibility.Visible;
                        FoodTextBoxVisibility = Visibility.Hidden;
                        DrinkTextBoxVisibility = Visibility.Hidden;
                        ModificatorTextBoxVisibility = Visibility.Hidden;
                        break;
                    }
                case UserControlType.FoodUserControl:
                    {
                        CurrentUserControl = new FoodUserControl();
                        foodViewModel = new FoodViewModel();
                        CurrentUserControl.DataContext = foodViewModel;
                        ViewTypeAddItem = ViewType.AddFoodView;
                        ViewTypeEditItem = ViewType.EditFoodView;
                        UserTextBoxVisibility = Visibility.Hidden;
                        FoodTextBoxVisibility = Visibility.Visible;
                        DrinkTextBoxVisibility = Visibility.Hidden;
                        ModificatorTextBoxVisibility = Visibility.Hidden;
                        break;
                    }
                case UserControlType.DrinkUserControl:
                    {
                        CurrentUserControl = new DrinkUserControl();
                        drinkViewModel = new DrinkViewModel();
                        CurrentUserControl.DataContext = drinkViewModel;
                        ViewTypeAddItem = ViewType.AddDrinkView;
                        ViewTypeEditItem = ViewType.EditDrinkView;
                        UserTextBoxVisibility = Visibility.Hidden;
                        FoodTextBoxVisibility = Visibility.Hidden;
                        DrinkTextBoxVisibility = Visibility.Visible;
                        ModificatorTextBoxVisibility = Visibility.Hidden;
                        break;
                    }
                case UserControlType.ModificatorUserControl:
                    {
                        CurrentUserControl = new ModificatorUserControl();
                        modificatorViewModel = new ModificatorViewModel();
                        CurrentUserControl.DataContext = modificatorViewModel;
                        ViewTypeAddItem = ViewType.AddModificatorView;
                        ViewTypeEditItem = ViewType.EditModificatorView;
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
            DoOnLogOut(ViewType.AdminView);
        }

        private static void DoOnLogOut(ViewType e)
        {
            OnLogOut?.Invoke(null, e);
        }
    }
}
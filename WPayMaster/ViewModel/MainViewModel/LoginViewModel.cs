using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class LoginViewModel
    {
        public DataWork DWork = new DataWork();

        public static event EventHandler<TypeView> OnLogIn;

        public ICommand LogInCommand { get; set; }

        private ObservableCollection<User> UserList;

        public string Login { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            UserList = new ObservableCollection<User>(DWork.GetUsersList());
            LogInCommand = new CommandHandler(arg => LogIn());
        }

        private void LogIn()
        {
            if (Login != null && Password != null)
            {
                foreach (var user in UserList)
                {
                    if (user.UserName.Contains(Login) && user.Password.Contains(Password))
                    {
                        if (user.Post.Contains("Адміністратор"))
                            DoOnLogIn(TypeView.AdminView);
                        else DoOnLogIn(TypeView.OrderView);
                        return;
                    }
                }

                MessageBox.Show("Ви ввели неправильний логін або пароль", "Error");
            }
            else MessageBox.Show("Введіть будь ласка логін і пароль", "Error");
        }

        private static void DoOnLogIn(TypeView e)
        {
            OnLogIn?.Invoke(null, e);
        }
    }
}
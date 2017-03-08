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
        public static event Action<TypeView, string> OnLogIn;

        public DbService DbService = new DbService();

        public ICommand LogInCommand { get; set; }

        private ObservableCollection<User> UserList { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            UserList = new ObservableCollection<User>(DbService.GetUsersList());
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
                            DoOnLogIn(TypeView.AdminView, user.UserName + " " + user.Surname);
                        else DoOnLogIn(TypeView.OrderView, user.UserName + " " + user.Surname);
                        return;
                    }
                }

                MessageBox.Show("Ви ввели неправильний логін або пароль", "Error");
            }
            else MessageBox.Show("Введіть будь ласка логін і пароль", "Error");
        }


        private static void DoOnLogIn(TypeView arg1, string arg2)
        {
            OnLogIn?.Invoke(arg1, arg2);
        }
    }
}
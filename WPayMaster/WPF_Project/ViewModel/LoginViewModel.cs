using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared.Command;
using Shared.Enum;

namespace WPF_Project.ViewModel
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
            LogInCommand = new MainCommand(arg => LogIn());
        }

        private void LogIn()
        {
            foreach (var user in UserList)
            {
                if (user.NameUser.Contains(Login) && user.Password.Contains(Password))
                {
                    if (user.Post.Contains("Адміністратор"))
                        DoOnLogIn(TypeView.AdminView);
                    else DoOnLogIn(TypeView.OrderView);
                    return;                    
                }
            }

            MessageBox.Show("Ви ввели неправильний пароль або логін");
        }

        private static void DoOnLogIn(TypeView e)
        {
            OnLogIn?.Invoke(null, e);
        }
    }
}
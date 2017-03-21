using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public User SelectedItem { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }

        public List<string> UserPostList { get; set; }

        public EditUserViewModel(User item)
        {
            SelectedItem = item;

            Name = item.UserName;
            Surname = item.Surname;
            PassportNumber = item.PassportNumber;
            Post = item.Post;
            Password = item.Password;
            Salary = item.Salary;

            UserPostList = new List<string>(DbService.CreateTypeList(ViewType.AddUserView));

            CloseCommand = new CommandHandler(arg => Close());
            SaveItemCommand = new CommandHandler(arg => SaveItem());
            ClearCommand = new CommandHandler(arg => Clear());
        }

        private void Clear()
        {
            Name = " ";
            Surname = " ";
            PassportNumber = 0;
            Post = null;
            Password = " ";
            Salary = 0;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateUser(SelectedItem, Name, Surname, PassportNumber, Post, Password, Salary);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
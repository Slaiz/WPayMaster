using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

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
            SelectedItem = UserViewModel.SelectedItem;

            Name = item.UserName;
            Surname = item.Surname;
            PassportNumber = item.PassportNumber;
            Post = item.Post;
            Password = item.Password;
            Salary = item.Salary;

            UserPostList = new List<string>(DbService.CreateTypeList(TypeView.AddUserView));

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateUser(SelectedItem, Name, Surname, PassportNumber, Post, Password, Salary);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel()
        {
            Name = " ";
            Surname = " ";
            PassportNumber = 0;
            Post = null;
            Password = " ";
            Salary = 0;
        }
    }
}
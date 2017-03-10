using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class EditUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }

        public EditUserViewModel(User item)
        {
            Name = item.UserName;
            Surname = item.Surname;
            PassportNumber = item.PassportNumber;
            Post = item.Post;
            Password = item.Password;
            Salary = item.Salary;

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateUser(UserViewModel.SelectedItem, Name, Surname, PassportNumber, Post, Password, Salary);
        }

        private void Cancel()
        {
            Name = " ";
            Surname = " ";
            PassportNumber = 0;
            Post = " ";
            Password = " ";
            Salary = 0;
        }
    }
}
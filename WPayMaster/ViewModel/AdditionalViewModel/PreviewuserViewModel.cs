using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class PreviewUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }

        public User SelectedItem { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Sex { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string ImagePath { get; set; }

        public PreviewUserViewModel(User item)
        {
            SelectedItem = item;

            Name = item.UserName;
            Surname = item.Surname;
            PassportNumber = item.PassportNumber;
            Sex = item.Sex;
            Post = item.Post;
            Password = item.Password;
            Salary = item.Salary;

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

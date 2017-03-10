using System.Windows.Input;
using DataBaseService;
using Shared;

namespace ViewModel.AdditionalViewModel
{
    public class AddUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand AddItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }

        public AddUserViewModel()
        {
            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void AddItem()
        {
            DbService.AddUser(Name, Surname, PassportNumber, Post, Password, Salary);
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
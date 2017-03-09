using DataBaseService;
using DataBaseService.Model;

namespace ViewModel.AdditionalViewModel
{
    public class EditUserViewModel
    {
        public DbService DbService = new DbService();

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
        }
    }
}
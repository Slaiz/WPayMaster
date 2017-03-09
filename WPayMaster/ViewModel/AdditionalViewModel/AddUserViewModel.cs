using DataBaseService;

namespace ViewModel.AdditionalViewModel
{
    public class AddUserViewModel
    {
        public DbService DbService = new DbService();

        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }

        public AddUserViewModel()
        {
            
        }
    }
}
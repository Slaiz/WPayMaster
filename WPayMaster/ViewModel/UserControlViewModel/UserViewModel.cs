using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;

namespace ViewModel.UserControlViewModel
{
    public class UserViewModel
    {
        public ObservableCollection<User> UserList;

        public DataWork DWork;


        public UserViewModel()
        {
            UserList = new ObservableCollection<User>(DWork.GetUsersList());
        }
    }
}
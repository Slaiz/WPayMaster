using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;
using Shared.Enum;

namespace ViewModel.UserControlViewModel
{
    public class UserViewModel
    {
        public static User SelectedItem { get; set; }
        public int Count { get; set; }
        public ObservableCollection<User> UserList { get; set; }

        public DbService DbService = new DbService();

        public UserViewModel()
        {
            UserList = new ObservableCollection<User>(DbService.GetUsersList());
            Count = UserList.Count;
        }
    }
}
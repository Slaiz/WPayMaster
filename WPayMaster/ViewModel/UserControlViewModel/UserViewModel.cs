using System;
using System.Collections.ObjectModel;
using System.Linq;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared.Enum;

namespace ViewModel.UserControlViewModel
{
    [ImplementPropertyChanged]
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

            DbService.OnAddUser += DoOnAddUser;
            DbService.OnUpdateUser += DoOnUpdateUser;
            DbService.OnDeleteUser += DoOnDeleteUser;
        }

        private void DoOnAddUser(object sender, User user)
        {
            UserList.Add(user);
        }


        private void DoOnUpdateUser(User oldUser, User newUser)
        {
            var user = UserList.First(x => x.PassportNumber == oldUser.PassportNumber);
            int index = UserList.IndexOf(user);

            UserList.RemoveAt(index);
            UserList.Insert(index, newUser);
        }

        private void DoOnDeleteUser(object sender, User user)
        {
            var newUser = UserList.First(x => x.PassportNumber == user.PassportNumber);
            UserList.Remove(newUser);
            Count = UserList.Count;
        }

    }
}
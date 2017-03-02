using System.Collections.Generic;
using DataBaseService.Model;

namespace DataBaseService.Interface
{
    public interface IDataWork
    {
        List<User> GetUsersList();
        void AddUser(string name, string surname, string post, string password);
    }
}
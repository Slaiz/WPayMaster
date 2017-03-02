using System.Collections.Generic;
using System.Linq;
using DataBaseService.Interface;
using DataBaseService.Model;

namespace DataBaseService
{
    public class DataWork:IDataWork
    {
        public List<User> GetUsersList()
        {
            using (var context = new ShopContext())
            {
                var users = context.Users.ToList();

                return users;
            }
        }

        public void AddUser(string name, string surname, string post,string password)
        {
            using (var context = new ShopContext())
            {
                User user = new User();

                user.NameUser = name;
                user.SurnameUser = surname;
                user.Post = post;
                user.Password = password;

                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}
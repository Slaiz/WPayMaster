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

        public List<Food> GetFoodsList()
        {
            throw new System.NotImplementedException();
        }

        public List<Drink> GetDrinksList()
        {
            throw new System.NotImplementedException();
        }

        public List<Modificator> GetModificatorsList()
        {
            throw new System.NotImplementedException();
        }

        public void AddUser(string name, string surname, int passportNumber, string post, string password, int salary, int workingTime)
        {
            using (var context = new ShopContext())
            {
                User user = new User();

                user.UserName = name;
                user.Surname = surname;
                user.PassportNumber = passportNumber;
                user.Post = post;
                user.Password = password;
                user.Salary = salary;
                user.WorkingTime = workingTime;

                context.Users.Add(user);

                context.SaveChanges();
            }
        }

        public void AddFood(string name, string type, int price, int cookTime, int foodWeight)
        {
            throw new System.NotImplementedException();
        }

        public void AddDrink(string name, string type, int price, int volume)
        {
            throw new System.NotImplementedException();
        }

        public void AddModificator(string name, string type, int price, int foodWeight)
        {
            throw new System.NotImplementedException();
        }
    }
}
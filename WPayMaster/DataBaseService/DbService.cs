using System.Collections.Generic;
using System.Linq;
using DataBaseService.Interface;
using DataBaseService.Model;
using Shared.Enum;

namespace DataBaseService
{
    public class DbService:IDbService
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
            using (var context = new ShopContext())
            {
                var foods = context.Foods.ToList();

                return foods;
            }
        }

        public List<Drink> GetDrinksList()
        {
            using (var context = new ShopContext())
            {
                var drinks = context.Drinks.ToList();

                return drinks;
            }
        }

        public List<Modificator> GetModificatorsList()
        {
            using (var context = new ShopContext())
            {
                var modificators = context.Modificators.ToList();

                return modificators;
            }
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

        public int GetCount(TypeUserControl typeUserControl)
        {
            using (var context = new ShopContext())
            {
                int count = 0;

                switch (typeUserControl)
                {
                    case TypeUserControl.UserUserControl:
                    {
                        count = context.Users.Count();
                        break;
                    }
                    case TypeUserControl.FoodUserControl:
                    {
                        count = context.Foods.Count();
                        break;
                    }
                    case TypeUserControl.DrinkUserControl:
                    {
                        count = context.Drinks.Count();
                        break;
                    }
                    case TypeUserControl.ModificatorUserControl:
                    {
                        count = context.Modificators.Count();
                        break;
                    }
                }

                return count;
            }
        }
    }
}
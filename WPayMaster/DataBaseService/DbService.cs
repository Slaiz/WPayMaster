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

        public void AddUser(string name, string surname, int passportNumber, string post, string password, int salary)
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
                user.WorkingTime = 0;

                context.Users.Add(user);

                context.SaveChanges();
            }
        }

        public void AddFood(string name, string type, int price, int cookTime, int weight)
        {
            using (var context = new ShopContext())
            {
                Food food = new Food();

                food.FoodName = name;
                food.FoodType = type;
                food.FoodPrice = price;
                food.CookTime = cookTime;
                food.FoodWeight = weight;

                context.Foods.Add(food);;

                context.SaveChanges();
            }
        }

        public void AddDrink(string name, string type, int price, int volume)
        {
            using (var context = new ShopContext())
            {
                Drink drink = new Drink();

                drink.DrinkName = name;
                drink.DrinkType = type;
                drink.DrinkPrice = price;
                drink.Volume = volume;

                context.Drinks.Add(drink);

                context.SaveChanges();
            }
        }

        public void AddModificator(string name, string type, int price, int weight)
        {
            using (var context = new ShopContext())
            {
                Modificator modificator = new Modificator();

                modificator.ModificatorName = name;
                modificator.ModificatorType = type;
                modificator.ModificatorPrice = price;
                modificator.ModificatorWeight = weight;

                context.Modificators.Add(modificator);

                context.SaveChanges();
            }
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
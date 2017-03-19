using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseService.Interface;
using DataBaseService.Model;
using Shared.Enum;

namespace DataBaseService
{
    public class DbService : IDbService
    {
        public static event EventHandler<User> OnAddUser;
        public static event EventHandler<Food> OnAddFood;
        public static event EventHandler<Drink> OnAddDrink;
        public static event EventHandler<Modificator> OnAddModificator;
        public static event Action<User, User> OnUpdateUser;
        public static event Action<Food, Food> OnUpdateFood;
        public static event Action<Drink, Drink> OnUpdateDrink;
        public static event Action<Modificator, Modificator> OnUpdateModificator;
        public static event EventHandler<User> OnDeleteUser;
        public static event EventHandler<Food> OnDeleteFood;
        public static event EventHandler<Drink> OnDeleteDrink;
        public static event EventHandler<Modificator> OnDeleteModificator;

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

        public List<History> GetStoryList()
        {
            using (var context = new ShopContext())
            {
                var story = context.Story.ToList();

                return story;
            }
        }

        public List<Food> GetTypeFoodList(FoodType foodType)
        {
            using (var context = new ShopContext())
            {
                var food = context.Foods.Where(x => x.FoodType == foodType.ToString())
                    .ToList();

                return food;
            }
        }

        public List<Drink> GetTypeDrinkList(DrinkType drinkType)
        {
            throw new NotImplementedException();
        }

        public List<Modificator> GetTypeModificatorList(ModificatorType modificatorType)
        {
            throw new NotImplementedException();
        }

        #region AddItem
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
                user.WorkingTime = TimeSpan.Zero;

                context.Users.Add(user);

                context.SaveChanges();

                DoOnAddUser(user);
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

                context.Foods.Add(food);

                context.SaveChanges();

                DoOnAddFood(food);
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

                DoOnAddDrink(drink);
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

                DoOnAddModificator(modificator);
            }
        }
        #endregion

        #region UpdateItem
        public void UpdateUser(User item, string name, string surname, int passportNumber, string post, string password, int salary)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.First(x => x.PassportNumber == item.PassportNumber);

                user.UserName = name;
                user.Surname = surname;
                user.PassportNumber = passportNumber;
                user.Post = post;
                user.Password = password;
                user.Salary = salary;
                user.WorkingTime = TimeSpan.Zero;

                context.SaveChanges();

                DoOnUpdateUser(item, user);
            }
        }

        public void UpdateFood(Food item, string name, string type, int price, int cookTime, int weight)
        {
            using (var context = new ShopContext())
            {
                var food = context.Foods.First(x => x.FoodId == item.FoodId);

                food.FoodName = name;
                food.FoodType = type;
                food.FoodPrice = price;
                food.CookTime = cookTime;
                food.FoodWeight = weight;

                context.SaveChanges();

                DoOnUpdateFood(item, food);
            }
        }

        public void UpdateDrink(Drink item, string name, string type, int price, int volume)
        {
            using (var context = new ShopContext())
            {
                var drink = context.Drinks.First(x => x.DrinkId == item.DrinkId);

                drink.DrinkName = name;
                drink.DrinkType = type;
                drink.DrinkPrice = price;
                drink.Volume = volume;

                context.SaveChanges();

                DoOnUpdateDrink(item, drink);
            }
        }

        public void UpdateModificator(Modificator item, string name, string type, int price, int weight)
        {
            using (var context = new ShopContext())
            {
                var modificator = context.Modificators.First(x => x.ModificatorId == item.ModificatorId);

                modificator.ModificatorName = name;
                modificator.ModificatorType = type;
                modificator.ModificatorPrice = price;
                modificator.ModificatorWeight = weight;

                context.SaveChanges();

                DoOnUpdateModificator(item, modificator);
            }
        }
        #endregion

        #region DeleteItem
        public void DeleteUser(User item)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.First(x => x.PassportNumber == item.PassportNumber);

                context.Users.Remove(user);

                context.SaveChanges();

                DoOnDeleteUser(user);
            }
        }

        public void DeleteFood(Food item)
        {
            using (var context = new ShopContext())
            {
                var food = context.Foods.First(x => x.FoodId == item.FoodId);

                context.Foods.Remove(food);

                context.SaveChanges();

                DoOnDeleteFood(food);
            }
        }

        public void DeleteDrink(Drink item)
        {
            using (var context = new ShopContext())
            {
                var drink = context.Drinks.First(x => x.DrinkId == item.DrinkId);

                context.Drinks.Remove(drink);

                context.SaveChanges();

                DoOnDeleteDrink(drink);
            }
        }

        public void DeleteModificator(Modificator item)
        {
            using (var context = new ShopContext())
            {
                var modificator = context.Modificators.First(x => x.ModificatorId == item.ModificatorId);

                context.Modificators.Remove(modificator);

                context.SaveChanges();

                DoOnDeleteModificator(modificator);
            }
        }
        #endregion


        public void WriteStory(User worker, TypeStory typeStory)
        {
            using (var context = new ShopContext())
            {
                var history = new History();

                history.UserName = worker.UserName;
                history.Surname = worker.Surname;
                history.Post = worker.Post;
                history.DateAction = DateTime.Now;

                switch (typeStory)
                {
                    case TypeStory.AddItemInDb:
                        {
                            history.ActionName = "Додано новий запис";
                            break;
                        }
                    case TypeStory.DeleteItemInDb:
                        {
                            history.ActionName = "Видалено запис";
                            break;
                        }
                    case TypeStory.UpdateItemInDb:
                        {
                            history.ActionName = "Оновлено запис";
                            break;
                        }
                    case TypeStory.UserLogIn:
                        {
                            history.ActionName = "Користувач увійшов в програму";
                            break;
                        }
                    case TypeStory.UserLogOut:
                        {
                            history.ActionName = "Користувач вийшов з програму";
                            break;
                        }
                    case TypeStory.CashierStopWork:
                        {
                            history.ActionName = "Касир закінчив зміну";
                            break;
                        }
                }
            }
        }

        public void AddWorkingTime(User oldUser, TimeSpan workingTime)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.First(x => x.PassportNumber == oldUser.PassportNumber);

                user.WorkingTime += workingTime;

                context.SaveChanges();
            }
        }

        public List<string> CreateTypeList(TypeView typeView)
        {
            List<string> list = new List<string>();

            switch (typeView)
            {
                case TypeView.AddUserView:
                    {
                        list.Add(UserPost.Адміністратор.ToString());
                        list.Add(UserPost.Касир.ToString());
                        break;
                    }
                case TypeView.AddFoodView:
                    {
                        list.Add("Салат");
                        list.Add("Перша страва");
                        list.Add("М'ясна страва");
                        list.Add("Рибна страва");
                        list.Add("Гарнір");
                        list.Add("Піца");
                        list.Add("Паста");
                        list.Add("Борошняний виріб");
                        list.Add("Десерт");
                        break;
                    }
                case TypeView.AddDrinkView:
                    {
                        list.Add("Сік");
                        list.Add("Гарячий напій");
                        list.Add("Холодний напій");
                        break;
                    }
                case TypeView.AddModificatorView:
                    {
                        list.Add("Закуска");
                        list.Add("Соуси");
                        break;
                    }

            }

            return list;
        }

        private static void DoOnAddUser(User e)
        {
            OnAddUser?.Invoke(null, e);
        }

        private static void DoOnAddFood(Food e)
        {
            OnAddFood?.Invoke(null, e);
        }

        private static void DoOnAddDrink(Drink e)
        {
            OnAddDrink?.Invoke(null, e);
        }

        private static void DoOnAddModificator(Modificator e)
        {
            OnAddModificator?.Invoke(null, e);
        }

        private static void DoOnUpdateUser(User arg1, User arg2)
        {
            OnUpdateUser?.Invoke(arg1, arg2);
        }

        private static void DoOnUpdateFood(Food arg1, Food arg2)
        {
            OnUpdateFood?.Invoke(arg1, arg2);
        }

        private static void DoOnUpdateDrink(Drink arg1, Drink arg2)
        {
            OnUpdateDrink?.Invoke(arg1, arg2);
        }

        private static void DoOnUpdateModificator(Modificator arg1, Modificator arg2)
        {
            OnUpdateModificator?.Invoke(arg1, arg2);
        }

        private static void DoOnDeleteUser(User e)
        {
            OnDeleteUser?.Invoke(null, e);
        }

        private static void DoOnDeleteFood(Food e)
        {
            OnDeleteFood?.Invoke(null, e);
        }

        private static void DoOnDeleteDrink(Drink e)
        {
            OnDeleteDrink?.Invoke(null, e);
        }

        private static void DoOnDeleteModificator(Modificator e)
        {
            OnDeleteModificator?.Invoke(null, e);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseService.Context;
using DataBaseService.Interface;
using DataBaseService.Model;
using Shared.Enums;

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
        public static event Action<List<OrderModel>, int> OnAddOrders;

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

        public List<CheckModel> GetCheckList()
        {
            using (var context = new ShopContext())
            {
                List<CheckModel> checkList = new List<CheckModel>();

                var orders = context.Orders.ToList();
                var groups = orders.GroupBy(order => order.CheckId);

                foreach (var group in groups)
                {
                    foreach (var item in group)
                    {
                        var check = new CheckModel();
                        check.CheckId = group.Key;
                        check.TotalSum = group.Sum(order => order.Sum);
                        check.Count = item.Count;
                        check.ItemName = item.ItemName;
                        check.ItemPrice = item.ItemPrice;
                        check.OrderId = item.OrderId;
                        check.CheckDate = item.CheckDate;
                        check.Sum = item.Sum;

                        checkList.Add(check);
                    }
                }

                return checkList;
            }
        }

        public List<OrderModel> GetSearchOrderList()
        {
            using (var context = new ShopContext())
            {
                List<OrderModel> orders = new List<OrderModel>();

                var foodOrders = context.Foods.AsEnumerable()
                            .Select(food => food.FoodToOrderModel())
                            .ToList();

                foreach (var foodOrder in foodOrders)
                {
                    orders.Add(foodOrder);
                }

                var drinkOrders = context.Drinks.AsEnumerable()
                                .Select(drink => drink.DrinkToOrderModel())
                                .ToList();

                foreach (var drinkOrder in drinkOrders)
                {
                    orders.Add(drinkOrder);
                }

                var modidficatorOrders = context.Modificators.AsEnumerable()
                                        .Select(modificator => modificator.ModificatorToOrderModel())
                                        .ToList();

                foreach (var modidficatorOrderOrder in modidficatorOrders)
                {
                    orders.Add(modidficatorOrderOrder);
                }

                return orders;
            }
        }

        public List<OrderModel> GetFoodOrderList(FoodType foodType)
        {
            using (var context = new ShopContext())
            {
                var orders = context.Foods.AsEnumerable()
                     .Where(x => x.FoodType == foodType.ToString())
                     .Select(food => food.FoodToOrderModel())
                     .ToList();

                return orders;
            }
        }
        public List<OrderModel> GetDrinkOrderList(DrinkType drinkType)
        {
            using (var contex = new ShopContext())
            {
                var orders = contex.Drinks.AsEnumerable()
                    .Where(x => x.DrinkType == drinkType.ToString())
                    .Select(drink => drink.DrinkToOrderModel())
                    .ToList();

                return orders;
            }
        }

        public List<OrderModel> GetModificatorOrderList(ModificatorType modificatorType)
        {
            using (var context = new ShopContext())
            {
                var orders = context.Modificators.AsEnumerable()
                    .Where(x => x.ModificatorType == modificatorType.ToString())
                    .Select(modificator => modificator.ModificatorToOrderModel())
                    .ToList();

                return orders;
            }
        }

        public void AddOrder(List<OrderModel> itemList, string cashierName)
        {
            using (var context = new ShopContext())
            {
                var lastItem = context.Orders.AsEnumerable().LastOrDefault();
                int checkNumber = 1;

                if (lastItem != null)
                    checkNumber = lastItem.CheckId+1;

                foreach (var item in itemList)
                {
                    var order = new Order();

                    order.CashierName = cashierName;
                    order.CheckId = checkNumber;
                    order.ItemId = item.ItemId;
                    order.ItemName = item.ItemName;
                    order.ItemType = item.ItemType;
                    order.ItemWeight = item.ItemWeight;
                    order.ItemPrice = item.ItemPrice;
                    order.CheckDate = DateTime.Now;
                    order.Count = item.Count.ItemCount;
                    order.Sum = item.Sum;

                    context.Orders.Add(order);
                }

                context.SaveChanges();
            }
        }

        #region AddItem
        public void AddUser(string name, string surname, int passportNumber, string sex, string post, string password, double tariffRate)
        {
            using (var context = new ShopContext())
            {
                User user = new User();

                user.UserName = name;
                user.Surname = surname;
                user.PassportNumber = passportNumber;
                user.Sex = sex;
                user.Post = post;
                user.Password = password;
                user.TariffRate = tariffRate;
                user.Salary = 0;
                user.WorkingTime = TimeSpan.Zero;

                context.Users.Add(user);

                context.SaveChanges();

                DoOnAddUser(user);
            }
        }

        public void AddFood(string name, string type, string recipe, int price, int weight)
        {
            using (var context = new ShopContext())
            {
                Food food = new Food();

                food.FoodName = name;
                food.FoodType = type;
                food.Recipe = recipe;
                food.FoodPrice = price;
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
        public void UpdateUser(User item, string name, string surname, int passportNumber, string sex, string post, string password, double tariffRate)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.First(x => x.PassportNumber == item.PassportNumber);

                user.UserName = name;
                user.Surname = surname;
                user.PassportNumber = passportNumber;
                user.Sex = sex;
                user.Post = post;
                user.Password = password;
                user.TariffRate = tariffRate;
                user.Salary = 0;
                user.WorkingTime = TimeSpan.Zero;

                context.SaveChanges();

                DoOnUpdateUser(item, user);
            }
        }

        public void UpdateFood(Food item, string name, string type, string recipe, int price, int weight)
        {
            using (var context = new ShopContext())
            {
                var food = context.Foods.First(x => x.FoodId == item.FoodId);

                food.FoodName = name;
                food.FoodType = type;
                food.Recipe = recipe;
                food.FoodPrice = price;
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

        public void WriteStory(User worker, string actionName)
        {
            using (var context = new ShopContext())
            {
                var history = new History();

                history.UserName = worker.UserName;
                history.Surname = worker.Surname;
                history.Post = worker.Post;
                history.DateAction = DateTime.Now;
                history.ActionName = actionName;

                context.Story.Add(history);

                context.SaveChanges();
            }
        }

        public void AddWorkingTime(User oldUser, TimeSpan? workingTime)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.First(x => x.PassportNumber == oldUser.PassportNumber);

                user.WorkingTime += workingTime;

                context.SaveChanges();
            }
        }

        public List<string> CreateTypeList(ViewType viewType, int type)
        {
            List<string> list = new List<string>();

            switch (viewType)
            {
                case ViewType.AddUserView:
                    {
                        if (type == 1)
                        {
                            list.Add(UserPost.Адміністратор.ToString());
                            list.Add(UserPost.Касир.ToString());
                        }
                        else
                        {
                            list.Add(UserSex.Чоловік.ToString());
                            list.Add(UserSex.Жінка.ToString());
                        }
                        break;
                    }
                case ViewType.AddFoodView:
                    {
                        list.Add(FoodType.Салат.ToString());
                        list.Add(FoodType.Першастрава.ToString());
                        list.Add(FoodType.Мяснастрава.ToString());
                        list.Add(FoodType.Рибнастрава.ToString());
                        list.Add(FoodType.Гарнір.ToString());
                        list.Add(FoodType.Піца.ToString());
                        list.Add(FoodType.Паста.ToString());
                        list.Add(FoodType.Борошнянийвиріб.ToString());
                        list.Add(FoodType.Десерт.ToString());
                        break;
                    }
                case ViewType.AddDrinkView:
                    {
                        list.Add(DrinkType.Сік.ToString());
                        list.Add(DrinkType.Гарячийнапій.ToString());
                        list.Add(DrinkType.Холоднийнапій.ToString());
                        break;
                    }
                case ViewType.AddModificatorView:
                    {
                        list.Add(ModificatorType.Закуска.ToString());
                        list.Add(ModificatorType.Соус.ToString());
                        break;
                    }

            }

            return list;
        }

        public static void ConvertString(FoodType foodType)
        {

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

        public static void DoOnAddOrders(List<OrderModel> arg1, int arg2)
        {
            OnAddOrders?.Invoke(arg1, arg2);
        }
    }
}
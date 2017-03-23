using System;
using System.Collections.Generic;
using DataBaseService.Context;
using DataBaseService.Model;
using Shared.Enums;

namespace DataBaseService.Interface
{
    public interface IDbService
    {
        List<User> GetUsersList();
        List<Food> GetFoodsList();
        List<Drink> GetDrinksList();
        List<Modificator> GetModificatorsList();
        List<History> GetStoryList();
        List<Order> GetCheckList();
        List<OrderModel> GetFoodOrderList(FoodType foodType);
        List<OrderModel> GetDrinkOrderList(DrinkType drinkType);
        List<OrderModel> GetModificatorOrderList(ModificatorType modificatorType);
        void AddOrder(List<OrderModel> itemList,string cashierName);
        void AddUser(string name, string surname, int passportNumber, string post, string password, int salary);
        void AddFood(string name, string type, int price, int weight);
        void AddDrink(string name, string type, int price, int volume);
        void AddModificator(string name, string type, int price, int weight);
        void UpdateUser(User item, string name, string surname, int passportNumber, string post, string password, int salary);
        void UpdateFood(Food item, string name, string type, int price, int weight);
        void UpdateDrink(Drink item, string name, string type, int price, int volume);
        void UpdateModificator(Modificator item, string name, string type, int price, int weight);
        void DeleteUser(User item);
        void DeleteFood(Food item);
        void DeleteDrink(Drink item);
        void DeleteModificator(Modificator item);
        void WriteStory(User worker, string actionName);
        void AddWorkingTime(User oldUser, TimeSpan? timeSpan);
        List<string> CreateTypeList(ViewType viewType); 
    }
}
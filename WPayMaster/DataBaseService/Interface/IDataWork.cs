using System.Collections.Generic;
using DataBaseService.Model;

namespace DataBaseService.Interface
{
    public interface IDataWork
    {
        List<User> GetUsersList();
        List<Food> GetFoodsList();
        List<Drink> GetDrinksList();
        List<Modificator> GetModificatorsList();
        void AddUser(string name, string surname, int passportNumber, string post, string password, int salary, int workingTime);
        void AddFood(string name, string type, int price, int cookTime, int foodWeight);
        void AddDrink(string name, string type, int price, int volume);
        void AddModificator(string name, string type, int price, int foodWeight);
    }
}
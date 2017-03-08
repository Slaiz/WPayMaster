using System.Collections.Generic;
using DataBaseService.Model;
using Shared.Enum;

namespace DataBaseService.Interface
{
    public interface IDbService
    {
        List<User> GetUsersList();
        List<Food> GetFoodsList();
        List<Drink> GetDrinksList();
        List<Modificator> GetModificatorsList();
        void AddUser(string name, string surname, int passportNumber, string post, string password, int salary);
        void AddFood(string name, string type, int price, int cookTime, int weight);
        void AddDrink(string name, string type, int price, int volume);
        void AddModificator(string name, string type, int price, int weight);
        int GetCount(TypeUserControl typeUserControl);
    }
}
using DataBaseService.Context;
using DataBaseService.Model;

namespace DataBaseService
{
    public static class Extensions
    {
        public static OrderModel FoodToOrderModel(this Food food)
        {
            return new OrderModel
            {
                ItemId = food.FoodId,
                ItemName = food.FoodName,
                ItemType = food.FoodType,
                ItemWeight = food.FoodWeight,
                ItemPrice = food.FoodPrice,
                Count = new Counting(0),
                Sum = 0
            };
        }

        public static OrderModel DrinkToOrderModel(this Drink drink)
        {
            return new OrderModel()
            {
                ItemId = drink.DrinkId,
                ItemName = drink.DrinkName,
                ItemType = drink.DrinkType,
                ItemWeight = drink.Volume,
                ItemPrice = drink.DrinkPrice,
                Count = new Counting(0),
                Sum = 0
            };
        }

        public static OrderModel ModificatorToOrderModel(this Modificator modificator)
        {
            return new OrderModel()
            {
                ItemId = modificator.ModificatorId,
                ItemName = modificator.ModificatorName,
                ItemType = modificator.ModificatorType,
                ItemWeight = modificator.ModificatorWeight,
                ItemPrice = modificator.ModificatorPrice,
                Count = new Counting(0),
                Sum = 0
            };
        }
    }
}
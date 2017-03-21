using DataBaseService.Model;

namespace DataBaseService
{
    public static class Extensions
    {
        public static Order FoodToOrder(this Food food)
        {
            return new Order
            {
                ItemId = food.FoodId,
                ItemName = food.FoodName,
                ItemType = food.FoodType,
                ItemWeight = food.FoodWeight,
                ItemPrice = food.FoodPrice,
                Count = 0, 
                Sum = 0
            };
        }

        public static Order DrinkToOrder(this Drink drink)
        {
            return new Order()
            {
                ItemId = drink.DrinkId,
                ItemName = drink.DrinkName,
                ItemType = drink.DrinkType,
                ItemWeight = drink.Volume,
                ItemPrice = drink.DrinkPrice,
                Count = 0,
                Sum = 0
            };
        }

        public static Order ModificatorToOrder(this Modificator modificator)
        {
            return new Order()
            {
                ItemId = modificator.ModificatorId,
                ItemName = modificator.ModificatorName,
                ItemType = modificator.ModificatorType,
                ItemWeight = modificator.ModificatorWeight,
                ItemPrice = modificator.ModificatorPrice,
                Count = 0,
                Sum = 0
            };
        }
    }
}
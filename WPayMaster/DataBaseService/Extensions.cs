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
                ItemType = food.FoodType,
                ItemWeight = food.FoodWeight,
                ItemPrice = food.FoodPrice,
                Count = 0
            };
        }

        public static Order DrinkToOrder(this Drink drink)
        {
            return new Order()
            {
                ItemId = drink.DrinkId,
                ItemType = drink.DrinkType,
                ItemWeight = drink.Volume,
                ItemPrice = drink.DrinkPrice,
                Count = 0
            };
        }

        public static Order ModificatorToOrder(this Modificator modificator)
        {
            return new Order()
            {
                ItemId = modificator.ModificatorId,
                ItemType = modificator.ModificatorType,
                ItemWeight = modificator.ModificatorWeight,
                ItemPrice = modificator.ModificatorPrice,
                Count = 0
            };
        }
    }
}
using System;
using System.Linq;
using DataBaseService.Context;
using DataBaseService.Interface;
using Shared.Enums;

namespace DataBaseService
{
    public class StatisticService :IStatisticService
    {
        public DbService DdService = new DbService();
        public string GetBestCashier()
        {
            throw new NotImplementedException();
        }

        public int GetMaxSumCheck()
        {
            var check = DdService.GetCheckList().ToList();
            return check.Max(item => item.TotalSum);
        }

        public int GetMinSumCheck()
        {
            var check = DdService.GetCheckList().ToList();
            return check.Min(item => item.TotalSum);
        }

        public double GetAvarageSumCheck()
        {
            var check = DdService.GetCheckList().ToList();
            return check.Average(item => item.TotalSum);
        }

        public int GetItemCount(TableName tableName)
        {
            switch (tableName)
            {
                case TableName.Food:
                    {
                        using (var context = new ShopContext())
                        {
                            var foods = context.Foods.ToList();

                            return foods.Count;
                        }
                    }
                case TableName.Drink:
                {
                    using (var context = new ShopContext())
                    {
                        var drinks = context.Drinks.ToList();

                        return drinks.Count;
                    }
                }
                case TableName.Modificator:
                {
                    using (var context = new ShopContext())
                    {
                        var modificators = context.Modificators.ToList();

                        return modificators.Count;
                    }
                }
                default: return 0;
            }
        }


        public string GetMaxValueItem(TableName tableName)
        {
            switch (tableName)
            {
                case TableName.Food:
                {
                    using (var context = new ShopContext())
                    {
                        var foods = context.Foods.ToList();
                        var price = foods.Max(item => item.FoodPrice);
                        var food = foods.FirstOrDefault(item => item.FoodPrice == price);

                        return $"{food.FoodName}, {price} грн";
                    }
                }
                case TableName.Drink:
                    {
                        using (var context = new ShopContext())
                        {
                            var drinks = context.Drinks.ToList();
                            var price = drinks.Max(item => item.DrinkPrice);
                            var drink = drinks.FirstOrDefault(item => item.DrinkPrice == price);

                            return $"{drink.DrinkName}, {price} грн";
                        }
                    }
                case TableName.Modificator:
                    {
                        using (var context = new ShopContext())
                        {
                            var modificators = context.Modificators.ToList();
                            var price = modificators.Max(item => item.ModificatorPrice);
                            var modificator = modificators.FirstOrDefault(item => item.ModificatorPrice == price);

                            return $"{modificator.ModificatorName}, {price} грн";
                        }
                    }
                default: return " ";
            }
        }

        public string GetMinValueItem(TableName tableName)
        {
            switch (tableName)
            {
                case TableName.Food:
                {
                    using (var context = new ShopContext())
                    {
                        var foods = context.Foods.ToList();

                        var price = foods.Min(item => item.FoodPrice);
                        var food = foods.FirstOrDefault(item => item.FoodPrice == price);

                        return $"{food.FoodName}, {price} грн";
                        }
                }
                case TableName.Drink:
                {
                    using (var context = new ShopContext())
                    {
                        var drinks = context.Drinks.ToList();
                        var price = drinks.Min(item => item.DrinkPrice);
                        var drink = drinks.FirstOrDefault(item => item.DrinkPrice == price);

                        return $"{drink.DrinkName}, {price} грн";
                        }
                }
                case TableName.Modificator:
                {
                    using (var context = new ShopContext())
                    {
                        var modificators = context.Modificators.ToList();
                        var price = modificators.Min(item => item.ModificatorPrice);
                        var modificator = modificators.FirstOrDefault(item => item.ModificatorPrice == price);

                        return $"{modificator.ModificatorName}, {price} грн";
                        }
                }
                default: return "";
            }
        }

        public string GetPopularItem(TableName tableName)
        {
            throw new NotImplementedException();
        }

        public string GetUnPopularItem(TableName tableName)
        {
            throw new NotImplementedException();
        }
    }
}

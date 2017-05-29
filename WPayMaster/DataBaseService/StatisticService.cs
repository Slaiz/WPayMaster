using System;
using System.Linq;
using DataBaseService.Context;
using DataBaseService.Interface;
using Shared.Enums;

namespace DataBaseService
{
    public class StatisticService : IStatisticService
    {
        public string GetBestCashier()
        {
            throw new NotImplementedException();
        }

        public int GetMaxSumCheck()
        {
            throw new NotImplementedException();
        }

        public int GetMinSumCheck()
        {
            throw new NotImplementedException();
        }

        public int GetAvarageSumCheck()
        {
            throw new NotImplementedException();
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


        public int GetMaxValueItem(TableName tableName)
        {
            throw new NotImplementedException();
        }

        public int GetMinValueItem(TableName tableName)
        {
            throw new NotImplementedException();
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

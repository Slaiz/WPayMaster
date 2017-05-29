using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace DataBaseService.Interface
{
    interface IStatisticService
    {
        string GetBestCashier();
        int GetMaxSumCheck();
        int GetMinSumCheck();
        int GetAvarageSumCheck();
        int GetItemCount(TableName tableName);
        int GetMaxValueItem(TableName tableName);
        int GetMinValueItem(TableName tableName);
        string GetPopularItem(TableName tableName);
        string GetUnPopularItem(TableName tableName);
    }
}

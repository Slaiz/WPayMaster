using Shared.Enums;

namespace DataBaseService.Interface
{
    interface IStatisticService
    {
        string GetBestCashier();
        int GetMaxSumCheck();
        int GetMinSumCheck();
        double GetAvarageSumCheck();
        int GetItemCount(TableName tableName);
        string GetMaxValueItem(TableName tableName);
        string GetMinValueItem(TableName tableName);
        string GetPopularItem(TableName tableName);
        string GetUnPopularItem(TableName tableName);
    }
}

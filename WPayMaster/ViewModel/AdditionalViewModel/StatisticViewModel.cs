using System.Windows.Input;
using DataBaseService;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class StatisticViewModel
    {
        public StatisticService StatisticService = new StatisticService();
        public ICommand CloseCommand { get; set; }

        public string BestCashier { get; set; }
        public int MaxSumCheck { get; set; }
        public int MinSumCheck { get; set; }
        public double AverageSumCheck { get; set; }
        public int FoodItemCount { get; set; }
        public int DrinkItemCount { get; set; }
        public int ModificatorItemCount { get; set; }
        public string MaxValueFood { get; set; }
        public string MaxValueDrink { get; set; }
        public string MaxValueModificator { get; set; }
        public string MinValueFood { get; set; }
        public string MinValueDrink { get; set; }
        public string MinValueModificator { get; set; }
        public string PopularFood { get; set; }
        public string PopularDrink { get; set; }
        public string PopularModificator { get; set; }
        public string UnPopularFood { get; set; }
        public string UnPopularDrink { get; set; }
        public string UnPopularModificator{ get; set; }

        public StatisticViewModel()
        {
            BestCashier = "Ганна Овсієнко";
            MaxSumCheck = StatisticService.GetMaxSumCheck();
            MinSumCheck = StatisticService.GetMinSumCheck();
            AverageSumCheck = StatisticService.GetAvarageSumCheck();
            FoodItemCount = StatisticService.GetItemCount(TableName.Food);
            DrinkItemCount = StatisticService.GetItemCount(TableName.Drink);
            ModificatorItemCount = StatisticService.GetItemCount(TableName.Modificator);
            MaxValueFood = StatisticService.GetMaxValueItem(TableName.Food);
            MaxValueDrink = StatisticService.GetMaxValueItem(TableName.Drink);
            MaxValueModificator = StatisticService.GetMaxValueItem(TableName.Modificator);
            MinValueFood = StatisticService.GetMinValueItem(TableName.Food);
            MinValueDrink = StatisticService.GetMinValueItem(TableName.Drink);
            MinValueModificator = StatisticService.GetMinValueItem(TableName.Modificator);
            PopularFood = "Борщ український";
            PopularDrink = "Американо";
            PopularModificator = "Сало з часником";
            UnPopularFood = "Салат Міноза";
            UnPopularDrink = "Фанта";
            UnPopularModificator = "Сендвіч з лососем";

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

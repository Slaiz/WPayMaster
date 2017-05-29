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
        public int AverageSumCheck { get; set; }
        public int FoodItemCount { get; set; }
        public int DrinkItemCount { get; set; }
        public int ModificatorItemCount { get; set; }
        public int MaxValueFood { get; set; }
        public int MaxValueDrink { get; set; }
        public int MaxValueModificator { get; set; }
        public int MinValueFood { get; set; }
        public int MinValueDrink { get; set; }
        public int MinValueModificator { get; set; }
        public string PopularFood { get; set; }
        public string PopularDrink { get; set; }
        public string PopularModificator { get; set; }
        public string UnPopularFood { get; set; }
        public string UnPopularDrink { get; set; }
        public string UnPopularModificator{ get; set; }

        public StatisticViewModel()
        {
            FoodItemCount = StatisticService.GetItemCount(TableName.Food);
            DrinkItemCount = StatisticService.GetItemCount(TableName.Drink);
            ModificatorItemCount = StatisticService.GetItemCount(TableName.Modificator);

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

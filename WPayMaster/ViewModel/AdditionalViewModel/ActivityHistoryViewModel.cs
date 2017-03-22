using System.Collections.ObjectModel;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class ActivityHistoryViewModel
    {
        private DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }

        public ObservableCollection<History> StoryList { get; set; }

        public int Count { get; set;}

        public ActivityHistoryViewModel()
        {
            StoryList = new ObservableCollection<History>(DbService.GetStoryList());

            Count = StoryList.Count;

            CloseCommand = new CommandHandler(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}
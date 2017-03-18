using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;

namespace ViewModel.MainViewModel
{
    public class HistoryViewModel
    {
        private DbService DbService = new DbService(); 

        public ObservableCollection<History> StoryList { get; set; }

        public int Count { get; set;}

        public HistoryViewModel()
        {
            StoryList = new ObservableCollection<History>(DbService.GetStoryList());

            Count = StoryList.Count;
        } 
    }
}
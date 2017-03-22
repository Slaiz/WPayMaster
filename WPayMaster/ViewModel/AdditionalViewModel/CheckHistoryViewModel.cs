using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class CheckHistoryViewModel
    {
        private DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }

        public ListCollectionView CheckList { get; set; }

        public int Count { get; set; }

        public CheckHistoryViewModel()
        {
            CheckList = new ListCollectionView(DbService.GetCheckList());

            CheckList.GroupDescriptions.Add(new PropertyGroupDescription("CheckId"));

            Count = CheckList.Count;

            CloseCommand = new CommandHandler(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}
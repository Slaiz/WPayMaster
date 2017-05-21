using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class CheckHistoryViewModel
    {
        private DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }

        public ObservableCollection<CheckModel> CheckList { get; set; }
        public ListCollectionView List { get; set; }

        public int Count { get; set; }

        public CheckHistoryViewModel()
        {
            CheckList = new ObservableCollection<CheckModel>(DbService.GetCheckList());

            List = new ListCollectionView(CheckList); 
            List.GroupDescriptions.Add(new PropertyGroupDescription("CheckId"));

            Count = CheckList.Count;

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}
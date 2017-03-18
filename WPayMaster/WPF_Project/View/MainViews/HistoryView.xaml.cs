using System.Windows;
using Shared.Interface;
using ViewModel.MainViewModel;

namespace WPF_Project.View.MainViews
{
    /// <summary>
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : Window, IView
    {
        public HistoryView(HistoryViewModel historyViewModel)
        {
            DataContext = historyViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            throw new System.NotImplementedException();
        }
    }
}

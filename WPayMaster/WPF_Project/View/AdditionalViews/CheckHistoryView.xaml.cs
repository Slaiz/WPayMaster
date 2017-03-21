using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View.AdditionalViews
{
    /// <summary>
    /// Interaction logic for CheckHistoryView.xaml
    /// </summary>
    public partial class CheckHistoryView : Window, IView
    {
        public CheckHistoryView(CheckHistoryViewModel checkHistoryViewModel)
        {
            DataContext = checkHistoryViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
        }    
    }
}

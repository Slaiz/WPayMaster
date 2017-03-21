using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View.AdditionalViews
{
    /// <summary>
    /// Interaction logic for ActivityHistoryView.xaml
    /// </summary>
    public partial class ActivityHistoryView : Window, IView
    {
        public ActivityHistoryView(ActivityHistoryViewModel activityHistoryViewModel)
        {
            DataContext = activityHistoryViewModel;

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

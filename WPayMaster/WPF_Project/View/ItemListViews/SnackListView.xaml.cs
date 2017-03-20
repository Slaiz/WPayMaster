using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for SnackListView.xaml
    /// </summary>
    public partial class SnackListView : Window, IView
    {
        public SnackListView(SnackListViewModel snackListViewModel)
        {
            DataContext = snackListViewModel;

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

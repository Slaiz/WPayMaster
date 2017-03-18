using System.Windows;
using DataBaseService.Interface;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ListOrederView
{
    /// <summary>
    /// Interaction logic for SoupView.xaml
    /// </summary>
    public partial class SoupListView : Window, IView
    {
        public SoupListView(SoupListViewModel soupViewModel)
        {
            DataContext = soupViewModel;

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

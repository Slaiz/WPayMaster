using System.Windows;
using DataBaseService.Interface;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ListOrederView
{
    /// <summary>
    /// Interaction logic for SoupView.xaml
    /// </summary>
    public partial class SoupView : Window, IView
    {
        public SoupView(SoupViewModel soupViewModel)
        {
            DataContext = soupViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }

        public void CloseView()
        {
            throw new System.NotImplementedException();
        }
    }
}

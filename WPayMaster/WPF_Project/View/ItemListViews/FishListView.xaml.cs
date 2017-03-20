using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for FishListView.xaml
    /// </summary>
    public partial class FishListView : Window, IView
    {
        public FishListView(FishListViewModel fishListViewModel)
        {
            DataContext = fishListViewModel;

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

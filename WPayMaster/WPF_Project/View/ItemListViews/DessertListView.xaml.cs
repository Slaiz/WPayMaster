using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for DessertListView.xaml
    /// </summary>
    public partial class DessertListView : Window, IView
    {
        public DessertListView(DessertListViewModel dessertListViewModel)
        {
            DataContext = dessertListViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }
    }
}

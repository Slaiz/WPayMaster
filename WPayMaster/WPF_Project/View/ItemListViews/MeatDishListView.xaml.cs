using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for MeatDishListView.xaml
    /// </summary>
    public partial class MeatDishListView : Window, IView
    {
        public MeatDishListView(MeatDishListViewModel meatDishListViewModel)
        {
            DataContext = meatDishListViewModel;

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

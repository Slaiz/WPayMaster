using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for PizzaListView.xaml
    /// </summary>
    public partial class PizzaListView : Window, IView
    {
        public PizzaListView(PizzaListViewModel pizzaListViewModel)
        {
            DataContext = pizzaListViewModel;

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

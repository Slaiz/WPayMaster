using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for JuiceListView.xaml
    /// </summary>
    public partial class JuiceListView : Window, IView
    {
        public JuiceListView(JuiceListViewModel juiceListViewModel)
        {
            DataContext = juiceListViewModel;

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

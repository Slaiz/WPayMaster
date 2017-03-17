using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for PastaListView.xaml
    /// </summary>
    public partial class PastaListView : Window, IView
    {
        public PastaListView(PastaListViewModel pastaListViewModel)
        {
            DataContext = pastaListViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }
    }
}

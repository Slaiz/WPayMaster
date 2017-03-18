using System;
using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for HotDrinkListView.xaml
    /// </summary>
    public partial class HotDrinkListView : Window, IView
    {
        public HotDrinkListView(HotDrinkListViewModel hotDrinkListViewModel)
        {
            DataContext = hotDrinkListViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }
    }
}

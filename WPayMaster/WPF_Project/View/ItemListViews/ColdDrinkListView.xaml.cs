using System;
using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for ColdDrinkListView.xaml
    /// </summary>
    public partial class ColdDrinkListView : Window, IView
    {
        public ColdDrinkListView(ColdDrinkListViewModel coldDrinkListViewModel)
        {
            DataContext = coldDrinkListViewModel;

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

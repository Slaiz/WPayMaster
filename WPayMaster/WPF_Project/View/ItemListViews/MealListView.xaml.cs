using System;
using System.Windows;
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for MealListView.xaml
    /// </summary>
    public partial class MealListView : Window, IView
    {
        public MealListView(MealListViewModel mealListViewModel)
        {
            DataContext = mealListViewModel;

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

using System.Windows;
using DataBaseService.Interface;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddFoodView.xaml
    /// </summary>
    public partial class AddFoodView : Window, IView
    {
        public AddFoodView(AddFoodViewModel addFoodViewModel)
        {
            DataContext = addFoodViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

    }
}

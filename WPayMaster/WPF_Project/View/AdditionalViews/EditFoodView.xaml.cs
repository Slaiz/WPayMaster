using System.Windows;
using DataBaseService.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for EditFoodView.xaml
    /// </summary>
    public partial class EditFoodView : Window, IView
    {
        public EditFoodView(EditFoodViewModel editFoodViewModel)
        {
            DataContext = editFoodViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

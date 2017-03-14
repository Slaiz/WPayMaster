using System.Windows;
using DataBaseService.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddDrinkView.xaml
    /// </summary>
    public partial class AddDrinkView : Window, IView
    {
        public AddDrinkView(AddDrinkViewModel addDrinkViewModel)
        {
            DataContext = addDrinkViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

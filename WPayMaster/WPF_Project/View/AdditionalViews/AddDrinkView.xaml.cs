using System.Windows;
using Shared.Interface;
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
            ShowDialog();
        }

        public void CloseView()
        {
            throw new System.NotImplementedException();
        }
    }
}

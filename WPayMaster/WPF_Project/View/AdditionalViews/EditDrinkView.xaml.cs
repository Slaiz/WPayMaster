using System.Windows;
using DataBaseService.Interface;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for EditDrinkView.xaml
    /// </summary>
    public partial class EditDrinkView : Window, IView
    {
        public EditDrinkView(EditDrinkViewModel editDrinkViewModel)
        {
            DataContext = editDrinkViewModel;

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

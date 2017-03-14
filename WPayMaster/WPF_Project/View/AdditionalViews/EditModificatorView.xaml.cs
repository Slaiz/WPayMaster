using System.Windows;
using DataBaseService.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for EditModificatorView.xaml
    /// </summary>
    public partial class EditModificatorView : Window, IView
    {
        public EditModificatorView(EditModificatorViewModel editModificatorViewModel)
        {
            DataContext = editModificatorViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

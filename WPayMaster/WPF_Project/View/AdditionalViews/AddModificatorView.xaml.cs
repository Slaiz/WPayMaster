using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddModificatorView.xaml
    /// </summary>
    public partial class AddModificatorView : Window,IView
    {
        public AddModificatorView(AddModificatorViewModel addModificatorViewModel)
        {
            DataContext = addModificatorViewModel;

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

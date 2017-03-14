using System.Windows;
using DataBaseService.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for EditUserView.xaml
    /// </summary>
    public partial class EditUserView : Window, IView
    {
        public EditUserView(EditUserViewModel editUserViewModel)
        {
            DataContext = editUserViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

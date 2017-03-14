using System.Windows;
using DataBaseService.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window,IView
    {
        public AddUserView(AddUserViewModel addUserViewModel)
        {
            DataContext = addUserViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

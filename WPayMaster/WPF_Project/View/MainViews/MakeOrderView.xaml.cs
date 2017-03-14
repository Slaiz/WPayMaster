using System.Windows;
using DataBaseService.Interface;
using ViewModel.MainViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for MakeOrderView.xaml
    /// </summary>
    public partial class MakeOrderView : Window,IView
    {
        public MakeOrderView(MakeOrderViewModel makeOrderViewModel)
        {
            DataContext = makeOrderViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

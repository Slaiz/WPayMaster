using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataBaseService.Interface;
using DataBaseService.Model;
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

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
            Show();
        }
    }
}

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

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for MakeOrderView.xaml
    /// </summary>
    public partial class MakeOrderView : Window,IView
    {
        public MakeOrderView()
        {
            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

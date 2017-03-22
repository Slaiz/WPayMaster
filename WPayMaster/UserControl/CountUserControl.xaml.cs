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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControl
{
    /// <summary>
    /// Interaction logic for CountUserControl.xaml
    /// </summary>
    public partial class CountUserControl : System.Windows.Controls.UserControl
    {
        public CountUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CountTextBox.Text = (Convert.ToInt32(CountTextBox.Text) - 1).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CountTextBox.Text = (Convert.ToInt32(CountTextBox.Text) + 1).ToString();
        }
    }
}

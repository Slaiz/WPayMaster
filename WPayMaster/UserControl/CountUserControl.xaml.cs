using System;
using System.Windows;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for CountUserControl.xaml
    /// </summary>
    public partial class CountUserControl
    {
        public CountUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(CountTextBox.Text) > 0)
                CountTextBox.Text = (Convert.ToInt32(CountTextBox.Text) - 1).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CountTextBox.Text = (Convert.ToInt32(CountTextBox.Text) + 1).ToString();
        }
    }
}

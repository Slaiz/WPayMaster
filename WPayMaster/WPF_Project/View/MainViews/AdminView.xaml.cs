using System.Windows;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
            TextBox1.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Visibility = Visibility.Visible;
            TextBox2.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.Visibility = Visibility.Hidden;
            TextBox2.Visibility = Visibility.Visible;
            TextBox3.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox1.Visibility = Visibility.Hidden;
            TextBox2.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Visible;
            TextBox4.Visibility = Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextBox1.Visibility = Visibility.Hidden;
            TextBox2.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Hidden;
            TextBox4.Visibility = Visibility.Visible;
        }
    }
}

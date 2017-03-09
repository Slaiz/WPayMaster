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
    /// Interaction logic for AddFoodView.xaml
    /// </summary>
    public partial class AddFoodView : Window, IView
    {
        public AddFoodView(AddFoodViewModel addFoodViewModel)
        {
            DataContext = addFoodViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}

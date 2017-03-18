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
using Shared.Interface;
using ViewModel.ItemListViewModel;

namespace WPF_Project.View.ItemListViews
{
    /// <summary>
    /// Interaction logic for MeatDishListView.xaml
    /// </summary>
    public partial class MeatDishListView : Window, IView
    {
        public MeatDishListView(MeatDishListViewModel meatDishListViewModel)
        {
            DataContext = meatDishListViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }
    }
}

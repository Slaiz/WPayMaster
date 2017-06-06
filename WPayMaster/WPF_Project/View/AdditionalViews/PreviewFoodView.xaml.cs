using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View.AdditionalViews
{
    /// <summary>
    /// Interaction logic for PreviewFoodView.xaml
    /// </summary>
    public partial class PreviewFoodView : Window, IView
    {
        public PreviewFoodView(PreviewFoodViewModel previewFoodViewModel)
        {
            DataContext = previewFoodViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
        }
    }
}

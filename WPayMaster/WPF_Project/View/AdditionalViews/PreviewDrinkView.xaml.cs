using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View.AdditionalViews
{
    /// <summary>
    /// Interaction logic for PreviewDrinkView.xaml
    /// </summary>
    public partial class PreviewDrinkView : Window, IView
    {
        public PreviewDrinkView(PreviewDrinkViewModel previewDrinkViewModel)
        {
            DataContext = previewDrinkViewModel;

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

using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View.AdditionalViews
{
    /// <summary>
    /// Interaction logic for PreviewModificatorView.xaml
    /// </summary>
    public partial class PreviewModificatorView : Window, IView
    {
        public PreviewModificatorView(PreviewModificatorViewModel previewModificatorViewModel)
        {
            DataContext = previewModificatorViewModel;

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

using System;
using System.Windows;
using Shared.Interface;
using ViewModel.AdditionalViewModel;

namespace WPF_Project.View.AdditionalViews
{
    /// <summary>
    /// Interaction logic for PreviewUserView.xaml
    /// </summary>
    public partial class PreviewUserView : Window, IView
    {
        public PreviewUserView(PreviewUserViewModel previewUserViewModel  )
        {
            DataContext = previewUserViewModel;

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

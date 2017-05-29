using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using Microsoft.Win32;
using PropertyChanged;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class AddModificatorViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string ImagePath { get; set; }

        public List<string> ModificatorTypeList { get; set; }

        public AddModificatorViewModel()
        {
            ModificatorTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddModificatorView, 0));

            CloseCommand = new Command(arg => Close());
            AddItemCommand = new Command(arg => AddItem());
            ClearCommand = new Command(arg => Clear());
            UploadCommand = new Command(arg => UploadImage());
        }

        private void UploadImage()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
            if (f.ShowDialog() == true)
            {
                ImagePath = f.FileName;
            }
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void AddItem()
        {
            DbService.AddModificator(Name, Type, Price, Weight);


            MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Clear()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Weight = 0;
        }
    }
}
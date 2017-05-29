using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using Microsoft.Win32;
using PropertyChanged;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditModificatorViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public Modificator SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string ImagePath { get; set; }

        public List<string> ModificatorTypeList { get; set; }

        public EditModificatorViewModel(Modificator item)
        {
            SelectedItem = item;

            Name = item.ModificatorName;
            Type = item.ModificatorType;
            Price = item.ModificatorPrice;
            Weight = item.ModificatorWeight;

            ModificatorTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddModificatorView, 0));

            CloseCommand = new Command(arg => Close());
            SaveItemCommand = new Command(arg => SaveItem());
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

        private void Clear()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Weight = 0;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateModificator(ModificatorViewModel.SelectedItem, Name, Type, Price, Weight);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
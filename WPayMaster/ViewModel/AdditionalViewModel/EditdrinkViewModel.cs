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

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditDrinkViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public Drink SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public string ImagePath { get; set; }

        public List<string> DrinkTypeList { get; set; }

        public EditDrinkViewModel(Drink item)
        {
            SelectedItem = item;

            Name = item.DrinkName;
            Type = item.DrinkType;
            Price = item.DrinkPrice;
            Volume = item.Volume;

            DrinkTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddDrinkView, 0));
            
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
            Volume = 0;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateDrink(SelectedItem, Name, Type, Price, Volume);


            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
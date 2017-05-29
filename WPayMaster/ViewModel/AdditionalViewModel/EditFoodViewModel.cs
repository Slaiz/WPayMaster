using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using Microsoft.Win32;
using PropertyChanged;
using Shared;
using Shared.Enums;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditFoodViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public Food SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Recipe { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string ImagePath { get; set; }

        public List<string> FoodTypeList { get; set;}

        public EditFoodViewModel(Food item)
        {
            SelectedItem = item;

            Name = item.FoodName;
            Type = item.FoodType;
            Recipe = item.Recipe;
            Price = item.FoodPrice;
            Weight = item.FoodWeight;

            FoodTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddFoodView, 0));

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
            Recipe = " ";
            Price = 0;
            Weight = 0;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateFood(SelectedItem, Name, Type, Recipe, Price, Weight);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
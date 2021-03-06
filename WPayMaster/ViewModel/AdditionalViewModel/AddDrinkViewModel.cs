﻿using System.Collections.Generic;
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
    public class AddDrinkViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public string ImagePath { get; set; }

        public List<string> DrinkTypeList { get; set; }

        public AddDrinkViewModel()
        {
            DrinkTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddDrinkView, 0));

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

        private void AddItem()
        {
            if (Name != null || Type != null || Price != 0 || Volume != 0)
                if (Price >= 1)
                {
                    if (Volume >= 1)
                    {
                        DbService.AddDrink(Name, Type, Price, Volume);

                        MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Введіть об'єм більше 0", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Введіть ціну більше 0", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            else MessageBox.Show("Бідь ласка заповніть всі поля", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
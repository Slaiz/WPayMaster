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
    public class EditUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand SaveItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public User SelectedItem { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Sex { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int TariffRate { get; set; }
        public string ImagePath { get; set; }

        public List<string> UserPostList { get; set; }
        public List<string> UserSexList { get; set; }

        public EditUserViewModel(User item)
        {
            SelectedItem = item;

            Name = item.UserName;
            Surname = item.Surname;
            PassportNumber = item.PassportNumber;
            Sex = item.Sex;
            Post = item.Post;
            Password = item.Password;
            TariffRate = item.TariffRate;

            UserPostList = new List<string>(DbService.CreateTypeList(ViewType.AddUserView, 1));
            UserSexList = new List<string>(DbService.CreateTypeList(ViewType.AddUserView, 1));

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
            Surname = " ";
            PassportNumber = 0;
            Sex = null;
            Post = null;
            Password = " ";
            TariffRate = 1;
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }

        private void SaveItem()
        {
            DbService.UpdateUser(SelectedItem, Name, Surname, PassportNumber, Sex, Post, Password, TariffRate);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
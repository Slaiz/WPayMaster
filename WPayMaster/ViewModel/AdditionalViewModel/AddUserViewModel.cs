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
    public class AddUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand CloseCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand UploadCommand { get; set; }

        public Visibility NameImageVisibility { get; set; }
        public Visibility SurnameImageVisibility { get; set; }
        public Visibility PassportNumberImageVisibility { get; set; }
        public Visibility SexImageVisibility { get; set; }
        public Visibility PostImageVisibility { get; set; }
        public Visibility PasswordImageVisibility { get; set; }
        public Visibility TariffRateImageVisibility { get; set; }
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


        public AddUserViewModel()
        {
            UserPostList = new List<string>(DbService.CreateTypeList(ViewType.AddUserView, 1));
            UserSexList = new List<string>(DbService.CreateTypeList(ViewType.AddUserView, 0));

            NameImageVisibility = Visibility.Hidden;
            SurnameImageVisibility = Visibility.Hidden;
            PassportNumberImageVisibility = Visibility.Hidden;
            SexImageVisibility = Visibility.Hidden;
            PostImageVisibility = Visibility.Hidden;
            PasswordImageVisibility = Visibility.Hidden;
            TariffRateImageVisibility = Visibility.Hidden;

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

        private void AddItem()
        {
            if (CheckData())
            {
                DbService.AddUser(Name, Surname, PassportNumber, Sex, Post, Password, TariffRate);
                MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Введіть всі поля правильно", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool CheckData()
        {
            var flag = true;

            if (Name != null) NameImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                NameImageVisibility = Visibility.Visible;
            }

            if (Surname != null) SurnameImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                SurnameImageVisibility = Visibility.Visible;
            }

            if (PassportNumber < 1000000000 && PassportNumber > 0 && PassportNumber % 1000000000 >= 100000000)
                PassportNumberImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                PassportNumberImageVisibility = Visibility.Visible; ;
            }

            if (Sex != null) PostImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                SexImageVisibility = Visibility.Visible;
            }

            if (Post != null) PostImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                PostImageVisibility = Visibility.Visible;
            }

            if (Password != null) PasswordImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                PasswordImageVisibility = Visibility.Visible;
            }

            if (TariffRate >= 1) TariffRateImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                TariffRateImageVisibility = Visibility.Visible;
            }

            return flag;
        }
    }
}
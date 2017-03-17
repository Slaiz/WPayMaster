using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using PropertyChanged;
using Shared;
using Shared.Enum;
using Shared.Interface;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class AddUserViewModel
    {
        public DbService DbService = new DbService();

        public ICommand AddItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public Visibility NameImageVisibility { get; set; }
        public Visibility SurnameImageVisibility { get; set; }
        public Visibility PassportNumberImageVisibility { get; set; }
        public Visibility PostImageVisibility { get; set; }
        public Visibility PasswordImageVisibility { get; set; }
        public Visibility SalaryImageVisibility { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }

        public List<string> UserPostList { get; set; }


        public AddUserViewModel()
        {
            UserPostList = new List<string>(DbService.CreateTypeList(TypeView.AddUserView));

            NameImageVisibility = Visibility.Hidden;
            SurnameImageVisibility = Visibility.Hidden;
            PassportNumberImageVisibility = Visibility.Hidden;
            PostImageVisibility = Visibility.Hidden;
            PasswordImageVisibility = Visibility.Hidden;
            SalaryImageVisibility = Visibility.Hidden;

            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void AddItem()
        {
            if (CheckData())
            {
                DbService.AddUser(Name, Surname, PassportNumber, Post, Password, Salary);
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

            if (Salary >= 1) SalaryImageVisibility = Visibility.Hidden;
            else
            {
                flag = false;
                SalaryImageVisibility = Visibility.Visible;
            }

            return flag;
        }

        private void Cancel()
        {
            Name = " ";
            Surname = " ";
            PassportNumber = 0;
            Post = null;
            Password = " ";
            Salary = 0;
        }
    }
}
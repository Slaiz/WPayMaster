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

        public Visibility PassportNumberImageVisibility { get; set; }
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

            PassportNumberImageVisibility = Visibility.Hidden;

            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void AddItem()
        {
            if (PassportNumber >= 100000000 || PassportNumber <= 0 || PassportNumber%100000000 <= 10000000)
                PassportNumberImageVisibility = Visibility.Visible;
            else
            {
                PassportNumberImageVisibility = Visibility.Hidden;

                DbService.AddUser(Name, Surname, PassportNumber, Post, Password, Salary);

                MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
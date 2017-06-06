using System;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Context;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class PreviewUserViewModel
    {
        public ICommand CloseCommand { get; set; }

        public User SelectedItem { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PassportNumber { get; set; }
        public string Sex { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public double TariffRate { get; set; }
        public int Salary { get; set; }
        public TimeSpan? WorkingTime { get; set; }
        public string ImagePath { get; set; }

        public PreviewUserViewModel(User item)
        {
            SelectedItem = item;

            Name = item.UserName;
            Surname = item.Surname;
            PassportNumber = item.PassportNumber;
            Sex = item.Sex;
            Post = item.Post;
            Password = item.Password;
            TariffRate = item.TariffRate;
            WorkingTime = item.WorkingTime;
            Salary = item.Salary;
            ImagePath = "E:\\Download\\Foto\\Coca Cola.jpg";

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

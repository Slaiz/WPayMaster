using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
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

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }

        public List<string> DrinkTypeList { get; set; }

        public AddDrinkViewModel()
        {
            DrinkTypeList = new List<string>(DbService.CreateTypeList(ViewType.AddDrinkView));

            CloseCommand = new CommandHandler(arg => Close());
            AddItemCommand = new CommandHandler(arg => AddItem());
            ClearCommand = new CommandHandler(arg => Clear());
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
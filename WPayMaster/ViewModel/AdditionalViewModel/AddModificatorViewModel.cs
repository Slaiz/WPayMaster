using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using PropertyChanged;
using Shared;
using Shared.Enum;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class AddModificatorViewModel
    {
        public DbService DbService = new DbService();

        public ICommand AddItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public List<string> ModificatorTypeList { get; set; }

        public AddModificatorViewModel()
        {
            ModificatorTypeList = new List<string>(DbService.CreateTypeList(TypeView.AddModificatorView));

            AddItemCommand = new CommandHandler(arg => AddItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void AddItem()
        {
            DbService.AddModificator(Name, Type, Price, Weight);


            MessageBox.Show("Запис додано", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel()
        {
            Name = " ";
            Type = null;
            Price = 0;
            Weight = 0;
        }
    }
}
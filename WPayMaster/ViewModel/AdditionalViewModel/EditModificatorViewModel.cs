using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using PropertyChanged;
using Shared;
using Shared.Enum;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    [ImplementPropertyChanged]
    public class EditModificatorViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public List<string> ModificatorTypeList { get; set; }

        public EditModificatorViewModel(Modificator item)
        {
            Name = item.ModificatorName;
            Type = item.ModificatorType;
            Price = item.ModificatorPrice;
            Weight = item.ModificatorWeight;

            ModificatorTypeList = new List<string>(DbService.CreateTypeList(TypeView.AddModificatorView));

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateModificator(ModificatorViewModel.SelectedItem, Name, Type, Price, Weight);

            MessageBox.Show("Запис оновлено", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
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
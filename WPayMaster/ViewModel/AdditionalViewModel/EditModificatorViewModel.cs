using System.Windows.Input;
using DataBaseService;
using DataBaseService.Model;
using Shared;
using ViewModel.UserControlViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class EditModificatorViewModel
    {
        public DbService DbService = new DbService();

        public ICommand SaveItemCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public EditModificatorViewModel(Modificator item)
        {
            Name = item.ModificatorName;
            Type = item.ModificatorType;
            Price = item.ModificatorPrice;
            Weight = item.ModificatorWeight;

            SaveItemCommand = new CommandHandler(arg => SaveItem());
            CancelCommand = new CommandHandler(arg => Cancel());
        }

        private void SaveItem()
        {
            DbService.UpdateModificator(ModificatorViewModel.SelectedItem, Name, Type, Price, Weight);
        }

        private void Cancel()
        {
            Name = " ";
            Type = " ";
            Price = 0;
            Weight = 0;
        }
    }
}
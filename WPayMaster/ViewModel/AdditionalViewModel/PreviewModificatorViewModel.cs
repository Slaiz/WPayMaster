using System.Collections.Generic;
using System.Windows.Input;
using DataBaseService.Context;
using Shared;
using ViewModel.MainViewModel;

namespace ViewModel.AdditionalViewModel
{
    public class PreviewModificatorViewModel
    {
        public ICommand CloseCommand { get; set; }

        public Modificator SelectedItem { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string ImagePath { get; set; }

        public List<string> ModificatorTypeList { get; set; }

        public PreviewModificatorViewModel(Modificator item)
        {
            SelectedItem = item;

            Name = item.ModificatorName;
            Type = item.ModificatorType;
            Price = item.ModificatorPrice;
            Weight = item.ModificatorWeight;
            ImagePath = "E:\\Download\\Foto\\Coca Cola.jpg";

            CloseCommand = new Command(arg => Close());
        }

        private void Close()
        {
            LoginViewModel.DoOnCloseView();
        }
    }
}

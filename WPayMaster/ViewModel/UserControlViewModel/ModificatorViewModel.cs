using System.Collections.ObjectModel;
using DataBaseService;
using DataBaseService.Model;
using Shared.Enum;

namespace ViewModel.UserControlViewModel
{
    public class ModificatorViewModel
    {
        public static Modificator SelectedItem { get; set; }
        public int Count { get; set; }

        public ObservableCollection<Modificator> ModificatorList { get; set; }

        public DbService DbService = new DbService(); 

        public ModificatorViewModel()
        {
            ModificatorList = new ObservableCollection<Modificator>(DbService.GetModificatorsList());
            Count = ModificatorList.Count;
        }
    }
}
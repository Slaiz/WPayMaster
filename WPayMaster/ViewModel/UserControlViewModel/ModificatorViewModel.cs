using System.Collections.ObjectModel;
using System.Linq;
using DataBaseService;
using DataBaseService.Context;
using DataBaseService.Model;
using PropertyChanged;

namespace ViewModel.UserControlViewModel
{
    [ImplementPropertyChanged]
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

            DbService.OnAddModificator += DoOnAddModificator;
            DbService.OnUpdateModificator += DoOnUpdateModificator;
            DbService.OnDeleteModificator += DoOnDeleteModificator;
        }

        private void DoOnAddModificator(object sender, Modificator modificator)
        {
            ModificatorList.Add(modificator);
            Count = ModificatorList.Count;
        }

        private void DoOnUpdateModificator(Modificator oldModificator, Modificator newModificator)
        {
            var modificator = ModificatorList.First( x => x.ModificatorId == oldModificator.ModificatorId);
            int index = ModificatorList.IndexOf(modificator);

            ModificatorList.RemoveAt(index);
            ModificatorList.Insert(index, newModificator);
        }


        private void DoOnDeleteModificator(object sender, Modificator modificator)
        {
            var oldModificator = ModificatorList.First(x => x.ModificatorId == modificator.ModificatorId);

            ModificatorList.Remove(oldModificator);
            Count = ModificatorList.Count;
        }

    }
}
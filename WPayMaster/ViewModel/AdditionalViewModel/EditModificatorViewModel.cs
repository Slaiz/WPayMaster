using DataBaseService;
using DataBaseService.Model;

namespace ViewModel.AdditionalViewModel
{
    public class EditModificatorViewModel
    {
        public DbService DbService = new DbService();

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
        }
    }
}
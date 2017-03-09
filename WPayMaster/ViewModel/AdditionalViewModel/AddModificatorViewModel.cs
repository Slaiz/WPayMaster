using DataBaseService;

namespace ViewModel.AdditionalViewModel
{
    public class AddModificatorViewModel
    {
        public DbService DbService = new DbService();

        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public AddModificatorViewModel()
        {
            
        }
    }
}
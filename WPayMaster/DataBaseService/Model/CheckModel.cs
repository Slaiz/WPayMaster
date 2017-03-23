using System.Collections.Generic;
using DataBaseService.Context;
using PropertyChanged;

namespace DataBaseService.Model
{
    [ImplementPropertyChanged]
    public class CheckModel
    {       
        public int CheckId { get; set; }
        public List<Order> OrderList { get; set; }
        public int TotalCount { get; set; }
        public int TotalSum { get; set; }
    }
}

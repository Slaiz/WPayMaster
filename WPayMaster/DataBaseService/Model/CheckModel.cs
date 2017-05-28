using System;
using System.Collections.Generic;
using DataBaseService.Context;
using PropertyChanged;

namespace DataBaseService.Model
{
    [ImplementPropertyChanged]
    public class CheckModel
    {       
        public int CheckId { get; set; }
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Count { get; set; }
        public int ItemPrice { get; set; }
        public int Sum { get; set; }
        public DateTime CheckDate { get; set; }
        public int TotalSum { get; set; }
    }
}

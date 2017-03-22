using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseService.Model
{
    class CheckModel
    {
        public int OrderId { get; set; }
        public int CheckId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int ItemWeight { get; set; }
        public Counting Count { get; set; }
        public int ItemPrice { get; set; }
        public int Sum { get; set; }
        public int TotalCount { get; set; }
        public int TotalSum { get; set; }
    }
}

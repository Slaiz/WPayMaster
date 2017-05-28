using System;
using PropertyChanged;

namespace DataBaseService.Model
{
    [ImplementPropertyChanged]
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CheckId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int ItemWeight { get; set; }
        public DateTime CheckDate { get; set; }
        public Counting Count { get; set; }
        public int ItemPrice { get; set; }
        public int Sum { get; set; }
    }
    [ImplementPropertyChanged]
    public class Counting
    {
        public Counting(int count)
        {
            ItemCount = count;
        }
        public int ItemCount { get; set; }
    }
}
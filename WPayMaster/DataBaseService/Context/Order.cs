using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Context
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string CashierName { get; set; }
        public int CheckId { get; set; }
        [Required]
        public int ItemId{ get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemType { get; set; }
        [Required]
        public int ItemWeight { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int ItemPrice { get; set; }
        public int Sum { get; set; }
    }
}
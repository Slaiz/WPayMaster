using System;
using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Model
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }
        [MaxLength(50)]
        [Required]
        public string Post { get; set; }
        [MaxLength(100)]
        [Required]
        public string ActionName { get; set; }
        public DateTime DateAction { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Context
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(50)]
        [Required]
        public string Surname{ get; set; }
        [Required]
        public int PassportNumber { get; set; }
        [MaxLength(50)]
        [Required]
        public string Post { get; set; }
        [MaxLength(10)]
        [Required]
        public string Password { get; set; }
        public int Salary { get; set; }
        public TimeSpan? WorkingTime { get; set; }
    }
}
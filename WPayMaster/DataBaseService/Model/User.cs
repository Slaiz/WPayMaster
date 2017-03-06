using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Surname{ get; set; }
        public int PassportNumber { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public int WorkingTime { get; set; }
    }
}
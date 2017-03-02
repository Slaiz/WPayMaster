using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string SurnameUser { get; set; }
        public string Post { get; set; }
        public string Password { get; set; }
    }
}
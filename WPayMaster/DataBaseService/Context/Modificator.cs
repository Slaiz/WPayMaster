using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Context
{
    public class Modificator
    {
        [Key]
        public int ModificatorId { get; set; }
        [MaxLength(50)]
        [Required]
        public string ModificatorName { get; set; }
        [MaxLength(50)]
        [Required]
        public string ModificatorType { get; set; }
        [Required]
        public int ModificatorPrice { get; set; }
        [Required]
        public int ModificatorWeight { get; set; }
    }
}
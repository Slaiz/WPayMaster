﻿using System.ComponentModel.DataAnnotations;

namespace DataBaseService.Context
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [MaxLength(50)]
        [Required]
        public string FoodName { get; set; }
        [MaxLength(50)]
        [Required]
        public string FoodType { get; set; }
        [MaxLength(100)]
        public string Recipe { get; set; }
        [Required]
        public int FoodPrice { get; set; }
        [Required]
        public int FoodWeight { get; set; }
        public byte[] Image { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace LR8.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }

}

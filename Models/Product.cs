using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models {
    public class Product {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
         public double Price { get; set; }
        public string Description { get; set; }

        [Required]
        public string ShippingCost { get; set; }
       
       
    }
}
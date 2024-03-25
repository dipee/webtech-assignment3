using Assignment3.Models;

namespace Assignment3.DTO {
    public class CartListDTO {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public int Quantity { get; set; }

        public CartProductDTO Product { get; set; }
    }
}
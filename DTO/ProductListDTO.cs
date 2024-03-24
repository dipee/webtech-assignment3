namespace Assignment3.DTO {
    public class ProductListDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ShippingCost { get; set; }

        public List<CommentListDTO> Comments { get; set; }
    }
}
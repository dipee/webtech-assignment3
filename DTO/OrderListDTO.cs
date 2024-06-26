namespace Assignment3.DTO {
    public class OrderListDTO {
       public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCost { get; set; }
        public string Total { get; set; }

        public List<OrderDetailListDTO> OrderDetails { get; set; }
    }
}
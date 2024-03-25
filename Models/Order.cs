namespace Assignment3.Models {
    public class Order {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreatedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCost { get; set; }
        public string Total { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
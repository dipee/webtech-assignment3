
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models {
    public class Order {
        public int Id { get; set; }
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCost { get; set; }
        public string Total { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models {
   
    public class Comment {
        public int Id { get; set; }
        public string Text { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
   
}
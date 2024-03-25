namespace Assignment3.DTO {
    // DTO to create a comment
    public class CommentCreateDTO {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
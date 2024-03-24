using Assignment3.Data;
using Assignment3.DTO;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CommentDTO> Get() {
            return _context.Comments.Select(c => new CommentDTO {
                Id = c.Id,
                Text = c.Text,
                Rating = c.Rating,
                Image = c.Image,
                ProductId = c.ProductId,
                UserId = c.UserId
            }).ToList();
        }

        [HttpPost]
        public CommentDTO Post(CommentDTO comment) {
            Comment newComment = new Comment {
                Text = comment.Text,
                Rating = comment.Rating,
                Image = comment.Image,
                ProductId = comment.ProductId,
                UserId = comment.UserId
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();
            comment.Id = newComment.Id;
            return comment;
           
        }

        [HttpPut("{id}")]
        public Comment Put(int id, Comment comment) {
            var existingComment = _context.Comments.Find(id);
            existingComment.Text = comment.Text;
            existingComment.ProductId = comment.ProductId;
            _context.Comments.Update(existingComment);
            _context.SaveChanges();
            return existingComment;
        }

        [HttpDelete("{id}")]
        public Comment Delete(int id) {
            Comment comment = _context.Comments.Find(id);

            // If the comment exists, remove it from the database
            if (comment != null) {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
            return comment;
        }
    }

}
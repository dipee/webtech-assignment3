
using Assignment3.Data;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;


namespace Assignment3.Controllers {
    
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get() {
            return _context.Users.ToList();
        }

        [HttpPost]
        public User Post(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpPut("{id}")]
        public User Put(int id, User user) {
            var existingUser = _context.Users.Find(id);
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.ShippingAddress = user.ShippingAddress;
            _context.Users.Update(existingUser);
            _context.SaveChanges();
            return existingUser;
        }

        [HttpDelete("{id}")]
        public User Delete(int id) {
            User user = _context.Users.Find(id);

            // If the user exists, remove it from the database
            if (user != null) {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return user;
        }
    }
}
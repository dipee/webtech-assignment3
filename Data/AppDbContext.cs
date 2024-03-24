using Assignment3.Models;
using Microsoft.EntityFrameworkCore; 

namespace Assignment3.Data {
    

    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Comment> Comments { get; set; }


    }
}
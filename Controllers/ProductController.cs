
using Assignment3.Data;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
namespace Assignment3.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get() {
            return _context.Products.ToList();
        }

        [HttpPost]
        public Product Post(Product product) {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        [HttpPut("{id}")]
        public Product Put(int id, Product product) {
            var existingProduct = _context.Products.Find(id);
            existingProduct.Name = product.Name;
            existingProduct.Image = product.Image;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.ShippingCost = product.ShippingCost;
            _context.Products.Update(existingProduct);
            _context.SaveChanges();
            return existingProduct;
        }
        [HttpDelete("{id}")]
        public Product Delete(int id) {
            Product product = _context.Products.Find(id);
            // If the product exists, remove it from the database
            if (product != null) {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }
        
    }
}
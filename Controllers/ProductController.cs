
using Assignment3.Data;
using Assignment3.DTO;
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
        // Get all products
        [HttpGet]
        public IEnumerable<ProductListDTO> Get() {
            return _context.Products.Select(p => new ProductListDTO {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Price = p.Price,
                Description = p.Description,
                ShippingCost = p.ShippingCost,
                Comments = p.Comments.Select(c => new CommentListDTO {
                    Id = c.Id,
                    Text = c.Text,
                    Rating = c.Rating,
                    Image = c.Image,
                    ProductId = c.ProductId,
                    UserId = c.UserId}).ToList()
            }).ToList();
        }

        // Create a new product
        [HttpPost]
        public ProductCreateDTO Post(ProductCreateDTO productDTO) {
            Product newProduct = new Product {
                Name = productDTO.Name,
                Image = productDTO.Image,
                Price = productDTO.Price,
                Description = productDTO.Description,
                ShippingCost = productDTO.ShippingCost
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            productDTO.Id = newProduct.Id;
            return productDTO;
        }

        // Update a product by id
        [HttpPut("{id}")]
        public ProductCreateDTO Put(int id, ProductCreateDTO productDTO) {
            var existingProduct = _context.Products.Find(id);
            existingProduct.Name = productDTO.Name;
            existingProduct.Image = productDTO.Image;
            existingProduct.Price = productDTO.Price;
            existingProduct.Description = productDTO.Description;
            existingProduct.ShippingCost = productDTO.ShippingCost;
            _context.Products.Update(existingProduct);
            _context.SaveChanges();
            productDTO.Id = existingProduct.Id;
            return productDTO;
            
        }

        // Delete a product by id
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
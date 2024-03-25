using Assignment3.Data;
using Assignment3.DTO;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers {
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context) {
            _context = context;
        }

        // Get all carts
        [HttpGet]
        public IEnumerable<CartListDTO> Get() {
            return _context.Carts.Select(c => new CartListDTO {
                Id = c.Id,
                ProductId = c.ProductId,
                UserId = c.UserId,
                Quantity = c.Quantity,
                Product = new CartProductDTO {
                    Id = c.Product.Id,
                    Name = c.Product.Name,
                    Image = c.Product.Image,
                    Price = c.Product.Price,
                    Description = c.Product.Description,
                    ShippingCost = c.Product.ShippingCost
                }
            }).ToList();
        }

        // Create a new cart
        [HttpPost]
        public CartCreateDTO Post(CartCreateDTO cartCreateDTO) {
            Cart newCart = new Cart {
                ProductId = cartCreateDTO.ProductId,
                UserId = cartCreateDTO.UserId,
                Quantity = cartCreateDTO.Quantity
            };
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            cartCreateDTO.Id = newCart.Id;
            return cartCreateDTO;
        }

        // Update a cart by id
        [HttpPut("{id}")]
        public CartCreateDTO Put(int id, CartCreateDTO cartCreateDTO) {
            var existingCart = _context.Carts.Find(id);
            existingCart.ProductId = cartCreateDTO.ProductId;
            existingCart.UserId = cartCreateDTO.UserId;
            existingCart.Quantity = cartCreateDTO.Quantity;
            _context.Carts.Update(existingCart);
            _context.SaveChanges();
            cartCreateDTO.Id = existingCart.Id;
            return cartCreateDTO;
        }

        // Delete a cart by id
        [HttpDelete("{id}")]
        public Cart Delete(int id) {
            Cart cart = _context.Carts.Find(id);

            // If the cart exists, remove it from the database
            if (cart != null) {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
            return cart;
        }
    }
}
using Assignment3.Data;
using Assignment3.DTO;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly AppDbContext _context;
        public OrderController(AppDbContext context) {
            _context = context;
        }
        // Get all orders
        [HttpGet]
        public IEnumerable<OrderListDTO> Get() {
            return _context.Orders.Select(o => new OrderListDTO {
                Id = o.Id,
                UserId = o.UserId,
                CreatedDate = o.CreatedDate,
                ShippingAddress = o.ShippingAddress,
                ShippingCost = o.ShippingCost,
                Total = o.Total,
                OrderDetails = o.OrderDetails.Select(od => new OrderDetailListDTO {
                    Id = od.Id,
                    Quantity = od.Quantity,
                    Product = new CartProductDTO {
                        Id = od.Product.Id,
                        Name = od.Product.Name,
                        Image = od.Product.Image,
                        Price = od.Product.Price,
                        Description = od.Product.Description
                    }

                }).ToList()
            }).ToList();
        }

        // Create a new order
        [HttpPost]
        public OrderCreateDTO Post(OrderCreateDTO orderDTO) {
           //get OrderDetails from orderDTO and save to database with newly created OrderId 
            Order newOrder = new Order {
                UserId = orderDTO.UserId,
                CreatedDate = new System.DateTime(),
                ShippingAddress = orderDTO.ShippingAddress,
                ShippingCost = orderDTO.ShippingCost,
                Total = orderDTO.Total,
                OrderDetails = orderDTO.OrderDetails.Select(od => new OrderDetail {
                    Quantity = od.Quantity,
                    ProductId = od.ProductId
                }).ToList()
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            orderDTO.Id = newOrder.Id;
            return orderDTO;
        }
        // Update an order by id
        [HttpPut("{id}")]
        public OrderCreateDTO Put(int id, OrderCreateDTO orderDTO) {
            Order existingOrder = _context.Orders.Find(id);
            existingOrder.UserId = orderDTO.UserId;
            existingOrder.ShippingAddress = orderDTO.ShippingAddress;
            existingOrder.ShippingCost = orderDTO.ShippingCost;
            existingOrder.Total = orderDTO.Total;
            _context.Orders.Update(existingOrder);
            _context.SaveChanges();
            orderDTO.Id = existingOrder.Id;
            return orderDTO;
        }
        // Delete an order by id
        [HttpDelete("{id}")]
        public OrderCreateDTO Delete(int id) {
            Order order = _context.Orders.Find(id);
            if (order != null) {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return new OrderCreateDTO {
                Id = order.Id,
                UserId = order.UserId,
                ShippingAddress = order.ShippingAddress,
                ShippingCost = order.ShippingCost,
                Total = order.Total
              
            };
        }
    }
}
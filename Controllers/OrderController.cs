using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.Utility;
using MiniStore.ViewModels;

namespace MiniStore.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public OrderController(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ViewOrder>>> GetAllOrder()
        {
            var result = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Select(o => new ViewOrder
                {
                    OrderId = o.Id,
                    CreateDate = o.CreateDate,
                    CustomerName = o.CustomerName,
                    SalerId = o.SalerId,
                    Saler = o.Saler!.FullName,
                    TotalAmount = o!.TotalAmount,
                    TotalItems = o.TotalItems,
                    OrderDetails = o.OrderDetails.Select(od => new ViewOrderDetail
                    {
                        ProductId = od.ProductId,
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice,
                        Amount = od.Quantity * od.UnitPrice
                    }).ToList()
                })
                .ToListAsync();

            if (result == null) return NoContent();

            return Ok(result);
        }
        [EnableCors("Default")]
        [HttpGet("{orderId}")]
        public async Task<ActionResult<ViewOrder>> GetOrderById(string orderId)
        {
            var result = await _context.Orders
                .Where(string.IsNullOrEmpty(orderId) ? o => o.Id.Equals(orderId) : o => false)
                .Select(o => new ViewOrder
                {
                    OrderId = o.Id,
                    CreateDate = o.CreateDate,
                    CustomerName = o.CustomerName,
                    SalerId = o.SalerId,
                    Saler = o.Saler!.FullName,
                    TotalAmount = o!.TotalAmount,
                    TotalItems = o.TotalItems,
                })
                .FirstOrDefaultAsync();

            if (result == null) return NoContent();

            return Ok(result);
        }

        [EnableCors("Default")]
        [HttpPost("")]
        public async Task<IActionResult> CreateOrder(CreateOrder order)
        {
            List<OrderDetail> orderDetails = order.OrderDetails
                .Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                })
                .ToList();

            var saler = await _context.Employees.FirstOrDefaultAsync(e => e.Id == order.SalerId);
            if (saler == null) return BadRequest(new { Message = "Saler ID not correct!" });

            var isOverStock = orderDetails.Any(o => o.Quantity > _context.Products.Where(p => p.Id.Equals(o.ProductId)).Select(p => p.Stock).FirstOrDefault());

            if (isOverStock) return BadRequest(new { Message = "Over stock!" });

            var totalItems = (uint)order.OrderDetails.Sum(od => od.Quantity);
            var totalAmong = order.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);

            //await _context.OrderDetails.AddRangeAsync(orderDetails);

            Order model = new()
            {
                CreateDate = DateTime.Now,
                Id = Ultility.GenerateEightDigitId(),
                CustomerName = order.CustomerName,
                TotalItems = totalItems,
                TotalAmount = totalAmong,
                Cash = order.Cash,
                OrderDetails = orderDetails,
                StatusId = 2, //statusId = 2 for done the order
                SalerId = saler!.Id,
                Saler = saler
            };
            await _context.Orders.AddAsync(model);


            await _context.SaveChangesAsync();
            return Ok(new { Message = "Created order successfully", OrderId = model.Id });
        }
    }
}

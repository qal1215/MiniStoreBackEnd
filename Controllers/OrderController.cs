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

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ViewOrder>>> GetAllOrder()
        {
            var result = await _context.Orders
                .Select(o => new ViewOrder
                {
                    OrderId = o.Id,
                    CreateDate = o.CreateDate,
                    CustomerName = o.CustomerName,
                    SalerId = o.SalerId,
                    Saler = o.Saler!.FullName,
                    TotalAmount = o!.TotalAmount,
                    TotalItems = o.TotalItems,
                    StatusId = o.StatusId,
                })
                .ToListAsync();

            if (result == null) return NoContent();

            return Ok(result);
        }

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

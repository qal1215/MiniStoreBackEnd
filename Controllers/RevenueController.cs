using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.ViewModels;

namespace MiniStore.Controllers
{
    [Route("api/revenue")]
    public class RevenueController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public RevenueController(MiniStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [EnableCors("Default")]
        [HttpGet("range")]
        public async Task<ActionResult<RevenueResponse>> GetRevenueInRange(DateTime start, DateTime end)
        {
            List<Tuple<string, string>> products = await _context.Products
        .Select(c => Tuple.Create(c.Id, c.Name))
        .ToListAsync();

            if (products.Count == 0)
            {
                return BadRequest("No data");
            }

            List<RevenueResponse> result = new List<RevenueResponse>();

            foreach (var product in products)
            {
                var orderDetails = await _context.OrderDetails
                    .Where(c => c.ProductId.Equals(product.Item1) && c.Order.CreateDate >= start && c.Order.CreateDate <= end)
                    .ToListAsync();

                decimal totalAmount = 0;
                int quantity = 0;

                foreach (var item in orderDetails)
                {
                    totalAmount += item.UnitPrice * item.Quantity;
                    quantity += (int)item.Quantity;
                }

                if (totalAmount > 0 && quantity > 0)
                {
                    result.Add(new RevenueResponse { ProductId = product.Item1, ProductName = product.Item2, Quantity = quantity, TotalAmount = totalAmount });
                }
            }

            return Ok(result);
        }
        [EnableCors("Default")]
        [HttpGet("month")]
        public async Task<ActionResult<RevenueResponse>> GetRevenueInMonth(int year, int month)
        {
            List<Tuple<string, string>> products = await _context.Products
        .Select(c => Tuple.Create(c.Id, c.Name))
        .ToListAsync();

            if (products.Count == 0)
            {
                return BadRequest("No data");
            }

            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1); // Last day of the specified month

            List<RevenueResponse> result = new List<RevenueResponse>();

            foreach (var product in products)
            {
                var orderDetails = await _context.OrderDetails
                    .Where(c => c.ProductId.Equals(product.Item1) && c.Order.CreateDate >= startDate && c.Order.CreateDate <= endDate)
                    .ToListAsync();

                decimal totalAmount = 0;
                int quantity = 0;

                foreach (var item in orderDetails)
                {
                    totalAmount += item.UnitPrice * item.Quantity;
                    quantity += (int)item.Quantity;
                }

                if (totalAmount > 0 && quantity > 0)
                {
                    result.Add(new RevenueResponse { ProductId = product.Item1, ProductName = product.Item2, Quantity = quantity, TotalAmount = totalAmount });
                }
            }

            return Ok(result);
        }

    }

}

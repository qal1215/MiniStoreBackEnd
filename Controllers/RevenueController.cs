using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStore.Controllers
{
    public class RevenueController : ControllerBase
    {
        private readonly MiniStoreContext _context;
        public RevenueController(MiniStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet("revenue/range")]
        [EnableCors("default")]
        public async Task<ActionResult<RevenueResponse>> GetRevenueInRange(DateTime startRange, DateTime endRange)
        {
            var OrderInRange = await _context.Orders.Where(c => c.CreateDate >= startRange && c.CreateDate <= endRange).ToListAsync();
            if (OrderInRange.Count == 0) return BadRequest("No order in these days");
            var TotalAmountInRange = OrderInRange.Select(c => c.TotalAmount).Sum();
            return Ok((OrderInRange,TotalAmountInRange));
        }
        [HttpGet("revenue/month")]
        [EnableCors("default")]
        public async Task<ActionResult<RevenueResponse>> GetRevenueInMonth(int month)
        {
            if (month < 1 || month > 12) return BadRequest("Invalid month");
            DateTime startRange = new DateTime(DateTime.Now.Year, month, 1).Date; //01-Jan-23 00:00:00
            DateTime endRange = startRange.AddMonths(1).AddTicks(-1);             //31-Jan-23 23:59:59.999
            var OrderInRange = await _context.Orders.Where(c => c.CreateDate >= startRange && c.CreateDate <= endRange).ToListAsync();
            if (OrderInRange.Count == 0) return BadRequest("No order in these days");
            var TotalAmountInRange = OrderInRange.Select(c => c.TotalAmount).Sum();
            return Ok((OrderInRange, TotalAmountInRange));
        }
        [HttpGet("revenue/day")]
        [EnableCors("default")]
        public async Task<ActionResult<RevenueResponse>> GetRevenueInADay(DateTime dateTime)
        {
            if (dateTime > DateTime.Now || dateTime < DateTime.MinValue) return BadRequest("Invalid day");
            DateTime startOfDay = dateTime.Date;                        //19-Aug-23 00:00:00
            DateTime endOfDay = startOfDay.AddDays(1).AddTicks(-1);     //19-Aug-23 23:59:59.999
            var OrderInDay = await _context.Orders.Where(c => c.CreateDate >= startOfDay && c.CreateDate <= endOfDay).ToListAsync();
            if (OrderInDay.Count == 0) return BadRequest("No order in these days");
            var TotalAmountInRange = OrderInDay.Select(c => c.TotalAmount).Sum();
            return Ok((OrderInDay, TotalAmountInRange));
        }
    }
    public class RevenueResponse
    {
        public List<Order> OrderInRange { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

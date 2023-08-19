using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;

namespace MiniStore.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CheckinCheckout : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public CheckinCheckout(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpPost("checkin")]
        public async Task<IActionResult> Checkin(ViewCheckin checkin)
        {
            var workshift = await _context.WorkShifts
                .Where(ws => ws.EmployeeId.Equals(checkin.EmployeeId))
                .Where(ws => ws.Id.Equals(checkin.WorkshiftId))
                .FirstOrDefaultAsync();

            if (workshift == null) return BadRequest(new { Message = "EmployeeId and WorkshiftId don't match!" });

            Models.CheckinCheckout model = new()
            {
                CheckinTime = checkin.DateTime,
                ImageCheckin = checkin.ImageData,
                WorkShift = workshift
            };

            await _context.CheckinCheckouts.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [EnableCors("Default")]
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(ViewCheckin checkin)
        {
            var workshift = await _context.WorkShifts
                .Where(ws => ws.EmployeeId.Equals(checkin.EmployeeId))
                .Where(ws => ws.Id.Equals(checkin.WorkshiftId))
                .FirstOrDefaultAsync();

            if (workshift == null) return BadRequest(new { Message = "EmployeeId and WorkshiftId don't match!" });

            var checkout = await _context.CheckinCheckouts
                .FirstOrDefaultAsync(c => c.WorkShiftId.Equals(checkin.WorkshiftId));

            if (checkout == null) return BadRequest(new { Message = "Please check-in first!" });

            checkout.CheckoutTime = checkin.DateTime;
            checkout.ImageCheckout = checkin.ImageData!;

            _context.CheckinCheckouts.Update(checkout);
            await _context.SaveChangesAsync();
            return Ok(new Ơ { });
        }

        public class ViewCheckin
        {
            public string? EmployeeId { get; set; }

            public DateTime DateTime { get; set; }

            public string? ImageData { get; set; }

            public string? WorkshiftId { get; set; }
        }
    }
}

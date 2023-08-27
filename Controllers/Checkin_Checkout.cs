using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.ViewModels;

namespace MiniStore.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Checkin_Checkout : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public Checkin_Checkout(MiniStoreContext context)
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

            var exist = await _context.CheckinCheckouts
                .Where(c => c.WorkshiftId.Equals(checkin.WorkshiftId))
                .FirstOrDefaultAsync();

            if (exist != null) return BadRequest(new { Message = "You have already checked in!" });

            Models.CheckinCheckout model = new()
            {
                CheckinTime = checkin.DateTime,
                ImageCheckin = checkin.ImageData,
                WorkshiftId = checkin.WorkshiftId!,
                Workshift = workshift
            };

            await _context.CheckinCheckouts.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Check in successfully!" });
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
                .FirstOrDefaultAsync(c => c.WorkshiftId.Equals(checkin.WorkshiftId));

            if (checkout == null) return BadRequest(new { Message = "Please check-in first!" });

            DateTime checkoutTime = checkout.CheckoutTime;

            if (checkoutTime.Year != 1) return BadRequest(new { Message = "You have already checked out!" });

            checkout.CheckoutTime = checkin.DateTime;
            checkout.ImageCheckout = checkin.ImageData;

            _context.CheckinCheckouts.Update(checkout);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Check out successfully!" });
        }
    }
}

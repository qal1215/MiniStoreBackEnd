using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.Utility;
using MiniStore.ViewModels;

namespace MiniStore.Controllers
{
    [Route("api/salary")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public SalaryController(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpPost]
        public async Task<IActionResult> InitSalary(InitSalary request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "No body content!" });
            }

            var employee = await _context.Employees.AnyAsync(e => e.Id.Equals(request.EmployeeId));

            if (!employee)
            {
                return BadRequest(new { Message = "Not found employee!" });
            }

            Payslip payslip = new()
            {
                PayslipId = Ultility.GenerateEightDigitId(),
                EmployeeId = request.EmployeeId,
                Month = request.Month,
                Year = request.Year,
                StartDay = request.StartDate,
                EndDay = request.EndDate,
            };

            await _context.Payslips.AddAsync(payslip);
            await _context.SaveChangesAsync();

            var workshifts = await _context.WorkShifts
                .Where(w => w.EmployeeId.Equals(request.EmployeeId)
                && w.StartDate.DayOfYear >= request.StartDate.DayOfYear
                && w.EndDate.DayOfYear <= request.EndDate.DayOfYear)
                .ToListAsync();

            if (workshifts == null)
            {
                return BadRequest(new { Message = "Not found workshifts!" });
            }

            payslip.WorkShifts = workshifts;

            _context.Payslips.Update(payslip);
            await _context.SaveChangesAsync();

            return Ok(payslip);
        }
    }
}

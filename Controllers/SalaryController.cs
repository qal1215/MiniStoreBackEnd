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
                BaseSalaryPerHour = request.BaseSalaryPerHour,
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

        [EnableCors("Default")]
        [HttpPost("{salaryId}")]
        public async Task<ActionResult<Payslip>> DoneSalary(string salaryId, DoneSalary request)
        {
            if (salaryId != request.SalaryId) return BadRequest(new { Message = "Fail on salaryId" });

            var salary = await _context.Payslips
                .Where(p => p.PayslipId.Equals(salaryId))
                .FirstOrDefaultAsync();

            if (salary == null) return BadRequest(new { Message = "Not found salary!" });

            salary.BaseSalary = request.BaseSalary;
            salary.Deductions = request.Deductions;
            salary.Bonuses = request.Bonuses;
            salary.TotalSalary = request.TotalSalary;

            _context.Payslips.Update(salary);
            await _context.SaveChangesAsync();
            return Ok(salary);
        }

        [EnableCors("Default")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Payslip>>> GetAllPayslips()
        {
            var payslips = await _context.Payslips.ToListAsync();

            if (payslips == null) return NoContent();

            return Ok(payslips);
        }

        [EnableCors("Default")]
        [HttpGet("{salaryId}")]
        public async Task<ActionResult<Payslip>> GetPayslipById(string salaryId)
        {
            var salary = await _context.Payslips
                .Where(p => p.PayslipId.Equals(salaryId))
                .FirstOrDefaultAsync();

            if (salary == null) return NoContent();

            return Ok(salary);
        }

    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.Utility;
using MiniStore.ViewModels;

namespace MiniStore.Controllers
{
    [Route("api/payslips")]
    [ApiController]
    public class PayslipsController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public PayslipsController(MiniStoreContext context)
        {
            _context = context;
        }

        // GET: api/Payslips
        [HttpGet]
        [EnableCors("default")]
        public async Task<ActionResult<IEnumerable<ViewPayslip>>> GetPayslips()
        {
            var result = await _context.Payslips
                  .Select(o => new ViewPayslip
                  {
                      PayslipId = o.PayslipId,
                      EmployeeName = o.Employee.FullName,
                      Month = o.Month,
                      BaseSalary = o.BaseSalary,
                      Deductions = o.Deductions,
                      Bonuses = o.Bonuses,
                      TotalSalary = o.TotalSalary,
                      StartDay = o.StartDay,
                      EndDate = o.EndDay,
                  })
                  .ToListAsync();

            if (result == null) return NoContent();

            return Ok(result);
        }

        // GET: api/Payslips/5
        [HttpGet("{id}")]
        [EnableCors("default")]
        public async Task<ActionResult<ViewPayslip>> GetPayslip(string id)
        {
            var result = await _context.Payslips
                  .Where(o => o.StartDay.Equals(id))
                  .Select(o => new ViewPayslip
                  {
                      PayslipId = o.PayslipId,
                      EmployeeName = o.Employee.FullName,
                      Month = o.Month,
                      BaseSalary = o.BaseSalary,
                      Deductions = o.Deductions,
                      Bonuses = o.Bonuses,
                      TotalSalary = o.TotalSalary,
                      StartDay = o.StartDay,
                      EndDate = o.EndDay,
                  })

                  .ToListAsync();

            if (result == null) return NoContent();

            return Ok(result);
        }

        // PUT: api/Payslips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("default")]

        public async Task<IActionResult> PutPayslip(string id, UpdatePayslip update)
        {
            if (update is null) return BadRequest(new { Message = "Empty payslip" });
            if (!id.Equals(update.PayslipId)) return BadRequest(new { Message = "Payslip Id has been wrong, please try again" });

            var result = await _context.Payslips
                    .Where(a => a.PayslipId == update.PayslipId)
                    .FirstOrDefaultAsync();

            if (result is null) return BadRequest(new { Message = "Invalid update!" });


            try
            {
                result.BaseSalary = update.BaseSalary;
                result.Deductions = update.Deductions;
                result.Bonuses = update.Bonuses;
                result.TotalSalary = update.BaseSalary - update.Deductions + update.Bonuses;
                result.StartDay = update.StartDay;
                result.EndDay = update.EndDate;
                _context.Payslips.Update(result);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Payslips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("default")]

        public async Task<ActionResult<Payslip>> PostPayslip(Payslip payslip)
        {
            Payslip model = new()
            {
                PayslipId = Ultility.GenerateEightDigitId(),
                EmployeeId = payslip.EmployeeId,
                WorkShifts = payslip.WorkShifts,
                Month = payslip.Month,
                Year = 2023,
                BaseSalary = payslip.BaseSalary,
                Deductions = payslip.Deductions,
                Bonuses = payslip.Bonuses,
                TotalSalary = payslip.TotalSalary,
                StartDay = payslip.StartDay,
                EndDay = payslip.EndDay,

            };
            _context.Payslips.Add(model);


            await _context.SaveChangesAsync();
            return Ok(new { Message = "Created payslip successfully" });
        }

        // DELETE: api/Payslips/5
        [HttpDelete("{id}")]
        [EnableCors("default")]
        public async Task<IActionResult> DeletePayslip(string id)
        {
            if (_context.Payslips == null)
            {
                return NotFound();
            }
            var payslip = await _context.Payslips.FindAsync(id);
            if (payslip == null)
            {
                return NotFound();
            }

            _context.Payslips.Remove(payslip);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.ViewModels;

namespace MiniStore.Controllers
{
    [Route("api/work-shift")]
    [ApiController]
    public class WorkShiftController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public WorkShiftController(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpPost("")]
        public async Task<IActionResult> RegisterWorkShift(RegisterWorkshift registerWorkshift)
        {
            List<WorkShift> workShifts = registerWorkshift.Workshifts
                .Select(ws => new WorkShift
                {
                    Id = Utility.Ultility.GenerateEightDigitId(),
                    EmployeeId = registerWorkshift.EmployeeId,
                    ApprovalStatus = _context.ApprovalStatuses.FirstOrDefault(ap => ap.Id.Equals(1))!,
                    StartDate = ws.StartDate,
                    EndDate = ws.EndDate,
                    WorkshiftType = _context.WorkshiftsType.FirstOrDefault(wst => wst.Name.Equals(ws.WorkshiftType))!,
                })
                .ToList();

            foreach (WorkShift ws in workShifts)
            {
                bool check = _context.WorkShifts
                .Where(ws1 => ws1.EmployeeId.Equals(ws.EmployeeId))
                .Any(ws1 => ws1.StartDate.DayOfYear.Equals(ws.StartDate.DayOfYear) && ws1.WorkshiftTypeId.Equals(ws.WorkshiftType.Id));

                if (!check)
                {
                    await _context.WorkShifts.AddAsync(ws);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(workShifts);
        }

        [EnableCors("Default")]
        [HttpGet("")]
        public async Task<ActionResult<WorkShift>> ShowRegisterWorkshifts(string employeeId, DateOnly startDate, DateOnly endDate)
        {
            var registerWorkshift = await _context.WorkShifts
                .Where(ws => ws.EmployeeId.Equals(employeeId))
                .Where(ws => ws.StartDate.DayOfYear >= startDate.DayOfYear && ws.EndDate.DayOfYear <= endDate.DayOfYear)
                .ToListAsync();

            return Ok(registerWorkshift);
        }

        //[EnableCors("Default")]
        //[]
    }
}

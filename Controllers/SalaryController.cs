﻿using Microsoft.AspNetCore.Cors;
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

        private static decimal CalculateHours(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeDifference = endDate - startDate;
            return (decimal)timeDifference.TotalHours;
        }

        [EnableCors("Default")]
        [HttpPost("")]
        public async Task<ActionResult<Payslip>> InitSalary(InitSalary request)
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

            var checkInitSalary = await _context.Payslips
                    .Where(p => p.EmployeeId.Equals(request.EmployeeId))
                    .Where(p => p.Month.Equals(request.Month) && p.Year.Equals(request.Year))
                    .Where(p => p.IsProcessing)
                    .FirstOrDefaultAsync();

            var ws = await _context.WorkShifts
               .Where(w => w.EmployeeId.Equals(request.EmployeeId))
               .Where(w => w.ApprovalStatusId.Equals(2))
               .Where(w => request.StartDate.DayOfYear <= w.StartDate.DayOfYear
                           && w.EndDate.DayOfYear <= request.EndDate.DayOfYear)
               .ToListAsync();

            foreach (Workshift workshift in ws)
            {
                var checkin = await _context.CheckinCheckouts
                    .Where(c => c.WorkshiftId.Equals(workshift.Id))
                    .FirstOrDefaultAsync();
            }

            ws = ws.Where(w => w.CheckinCheckout != null).ToList();



            decimal totalHours = ws.Sum(w => CalculateHours(w.StartDate, w.EndDate) * w.CoefficientsSalary);
            decimal salary = totalHours * request.BaseSalaryPerHour;



            if (checkInitSalary == null)
            {
                Payslip payslip = new()
                {
                    PayslipId = Ultility.GenerateEightDigitId(),
                    EmployeeId = request.EmployeeId,
                    BaseSalaryPerHour = request.BaseSalaryPerHour,
                    Month = request.Month,
                    Year = request.Year,
                    StartDay = request.StartDate,
                    EndDay = request.EndDate,
                    BaseSalary = salary,
                    TotalWorkHours = totalHours,
                    TotalSalary = salary,
                };
                payslip.WorkShifts = ws;
                await _context.Payslips.AddAsync(payslip);

                await _context.SaveChangesAsync();

                foreach (Workshift workshift in ws)
                {
                    workshift.CheckinCheckout = null;
                }

                return Ok(payslip);
            }
            else
            {
                checkInitSalary.TotalWorkHours = totalHours;
                checkInitSalary.TotalSalary = salary;
                checkInitSalary.WorkShifts = ws;

                _context.Payslips.Update(checkInitSalary);
                await _context.SaveChangesAsync();

                foreach (Workshift workshift in ws)
                {
                    workshift.CheckinCheckout = null;
                }

                return Ok(checkInitSalary);
            }

        }

        [EnableCors("Default")]
        [HttpPut("{salaryId}")]
        public async Task<ActionResult<Payslip>> DoneSalary(string salaryId, DoneSalary request)
        {
            if (salaryId != request.SalaryId) return BadRequest(new { Message = "Fail on salaryId" });

            var salary = await _context.Payslips
                .Where(p => p.PayslipId.Equals(salaryId))
                .FirstOrDefaultAsync();

            if (salary == null) return BadRequest(new { Message = "Not found salary!" });

            decimal checkTotal = request.BaseSalary + request.Bonuses - request.Deductions;

            if (!checkTotal.Equals(request.TotalSalary))
            {
                return BadRequest(new { Message = "Total salary is not correct!" });
            }

            salary.BaseSalary = request.BaseSalary;
            salary.Deductions = request.Deductions;
            salary.Bonuses = request.Bonuses;
            salary.TotalSalary = request.TotalSalary;
            salary.IsProcessing = false;

            _context.Payslips.Update(salary);
            await _context.SaveChangesAsync();
            return Ok(salary);
        }

        [EnableCors("Default")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Payslip>>> GetAllPayslips()
        {
            var payslips = await _context.Payslips
                .Where(payslips => !payslips.IsProcessing)
                .Include(p => p.WorkShifts)
                .ToListAsync();

            if (payslips == null) return NoContent();

            payslips.ForEach(p => p.Employee = _context.Employees.Select(e => new Employee { Id = e.Id, FullName = e.FullName }).FirstOrDefault(e => e.Id.Equals(p.EmployeeId)));
            return Ok(payslips);
        }

        [EnableCors("Default")]
        [HttpGet("{salaryId}")]
        public async Task<ActionResult<Payslip>> GetPayslipById(string salaryId)
        {
            var salary = await _context.Payslips
                .Where(p => p.PayslipId.Equals(salaryId))
                .Include(p => p.WorkShifts)
                .FirstOrDefaultAsync();

            if (salary == null) return NoContent();
            salary.Employee = _context.Employees.Select(e => new Employee { Id = e.Id, FullName = e.FullName }).FirstOrDefault(e => e.Id.Equals(salary.EmployeeId));

            return Ok(salary);
        }


        [EnableCors("Default")]
        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<Payslip>>> GetPayslipsByEmployeeId(string employeeId)
        {
            var payslips = await _context.Payslips
                .Where(p => !p.IsProcessing)
                .Where(p => p.EmployeeId.Equals(employeeId))
                .Include(p => p.WorkShifts)
                .ToListAsync();

            if (payslips == null) return NoContent();
            payslips.ForEach(p => p.Employee = _context.Employees.Select(e => new Employee { Id = e.Id, FullName = e.FullName }).FirstOrDefault(e => e.Id.Equals(p.EmployeeId)));
            return Ok(payslips);
        }
    }
}

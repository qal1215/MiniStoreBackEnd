using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStoreRepository.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public EmployeesController(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpPost("login")]
        public async Task<ActionResult<ViewEmployee>> Login(LoginRecord login)
        {
            var result = await _context.Employees
                .Where(a => a.Email.Equals(login.Email) && a.Password.Equals(login.Password) && a.IsActive == true)
                .Select(a => new ViewEmployee
                {
                    Id = a.Id,
                    Email = a.Email,
                    Position = a.Position.Name,
                    CreateDate = a.CreateDate,
                    ImgUrl = a.ImgUrl,
                    IsActive = a.IsActive
                })
                .FirstOrDefaultAsync();
            if (result == null) return Unauthorized();
            return Ok(result);
        }

        [EnableCors("Default")]
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(RegisterRecord Employee)
        {
            if (Employee is null) return BadRequest(new { Message = "Please give correct json!" });

            bool isExist = EmployeeExists(Employee.Email, Employee.Id);
            if (isExist) return BadRequest(new { Message = "Employee is existed." });

            Position? Position = _context.Positions.Where(r => r.Name.Equals(Employee.RoleName)).FirstOrDefault();
            if (Position is null) return NotFound(new { Message = "PositionId invalid!" });

            var EmployeeMap = new Employee
            {
                Id = Employee.Id,
                CreateDate = DateTime.Now,
                Email = Employee.Email,
                FullName = Employee.FullName,
                ImgUrl = Employee.ImgUrl,
                IsActive = true,
                Password = Employee.Password,
                Position = Position,
            };

            await _context.Employees.AddAsync(EmployeeMap);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [EnableCors("Default")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewEmployee>>> GetAllEmployees()
        {
            var result = await _context.Employees
                .Where(a => !a.Position.Id.Equals(1))
                .Select(a => new ViewEmployee
                {
                    Id = a.Id,
                    Email = a.Email,
                    FullName = a.FullName,
                    Position = a.Position.Name,
                    CreateDate = a.CreateDate,
                    ImgUrl = a.ImgUrl,
                    IsActive = a.IsActive
                }).ToListAsync();

            if (result is null) return NoContent();
            return Ok(result!);
        }

        [EnableCors("Default")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewEmployee>> GetEmployeeById(string id)
        {
            var result = await _context.Employees
                .Where(a => a.Id.Equals(id))
                .Select(a => new ViewEmployee
                {
                    Id = a.Id,
                    Email = a.Email,
                    FullName = a.FullName,
                    Password = a.Password,
                    Position = a.Position.Name,
                    CreateDate = a.CreateDate,
                    ImgUrl = a.ImgUrl,
                    IsActive = a.IsActive
                }).FirstOrDefaultAsync();

            if (result is null) return NotFound(new { Message = "Not found Employee" });
            return Ok(result!);
        }


        [EnableCors("Default")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ViewEmployee>> UpdateEmployee(string id, UpdateRecord update)
        {
            if (update is null) return BadRequest(new { Message = "Please give correct Employee" });
            if (!id.Equals(update.Id)) return BadRequest(new { Message = "Please give correct Employee" });

            var result = await _context.Employees
                    .Where(a => a.Id == update.Id)
                    .FirstOrDefaultAsync();

            if (result is null) return BadRequest(new { Message = "Invalid update!" });

            Position? Position = _context.Positions.Where(r => r.Name.Equals(update.RoleName)).FirstOrDefault();
            if (Position is null) return NotFound(new { Message = "PositionId invalid!" });


            try
            {
                result.IsActive = update.IsActive;
                result.Email = update.Email;
                result.Position = Position;
                result.FullName = update.FullName;
                result.ImgUrl = update.ImgUrl;
                result.Password = update.Password;

                _context.Employees.Update(result);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Something wrong\r\n" + ex.Message });
            }
        }

        [EnableCors("Default")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            try
            {
                var Employee = await _context.Employees.FirstOrDefaultAsync(a => a.Id.Equals(id));
                if (Employee == null) return NotFound();

                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }



        private bool EmployeeExists(string email, string id)
        {
            return (_context.Employees?.Any(e => e.Email == email || e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStore.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public AccountsController(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpPost("login")]
        public async Task<ActionResult<ViewAccount>> Login(LoginRecord login)
        {
            var result = await _context.Accounts
                .Where(a => a.Email.Equals(login.Email) && a.Password.Equals(login.Password) && a.IsActive == true)
                .Select(a => new ViewAccount
                {
                    Id = a.Id,
                    Email = a.Email,
                    Role = a.Role.Name,
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
        public async Task<IActionResult> CreateAsync(RegisterRecord account)
        {
            if (account is null) return BadRequest(new { Message = "Please give correct json!" });

            bool isExist = AccountExists(account.Email, account.Id);
            if (isExist) return BadRequest(new { Message = "Account is existed." });

            Role? role = _context.Roles.Where(r => r.Name.Equals(account.RoleName)).FirstOrDefault();
            if (role is null) return NotFound(new { Message = "RoleId invalid!" });

            var accountMap = new Account
            {
                Id = account.Id,
                CreateDate = DateTime.Now,
                Email = account.Email,
                FullName = account.FullName,
                ImgUrl = account.ImgUrl,
                IsActive = true,
                Password = account.Password,
                Role = role,
            };

            await _context.Accounts.AddAsync(accountMap);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [EnableCors("Default")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewAccount>>> GetAllEmployees()
        {
            var result = await _context.Accounts
                .Where(a => !a.Role.RoleId.Equals(1))
                .Select(a => new ViewAccount
                {
                    Id = a.Id,
                    Email = a.Email,
                    FullName = a.FullName,
                    Role = a.Role.Name,
                    CreateDate = a.CreateDate,
                    ImgUrl = a.ImgUrl,
                    IsActive = a.IsActive
                }).ToListAsync();

            if (result is null) return NoContent();
            return Ok(result!);
        }

        [EnableCors("Default")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewAccount>> GetAccountById(string id)
        {
            var result = await _context.Accounts
                .Where(a => a.Id.Equals(id))
                .Select(a => new ViewAccount
                {
                    Id = a.Id,
                    Email = a.Email,
                    FullName = a.FullName,
                    Password = a.Password,
                    Role = a.Role.Name,
                    CreateDate = a.CreateDate,
                    ImgUrl = a.ImgUrl,
                    IsActive = a.IsActive
                }).FirstOrDefaultAsync();

            if (result is null) return NotFound(new { Message = "Not found account" });
            return Ok(result!);
        }


        [EnableCors("Default")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ViewAccount>> UpdateAccount(string id, UpdateRecord update)
        {
            if (update is null) return BadRequest(new { Message = "Please give correct account" });
            if (!id.Equals(update.Id)) return BadRequest(new { Message = "Please give correct account" });

            var result = await _context.Accounts
                    .Where(a => a.Id == update.Id)
                    .FirstOrDefaultAsync();

            if (result is null) return BadRequest(new { Message = "Invalid update!" });

            Role? role = _context.Roles.Where(r => r.Name.Equals(update.RoleName)).FirstOrDefault();
            if (role is null) return NotFound(new { Message = "RoleId invalid!" });


            try
            {
                result.IsActive = update.IsActive;
                result.Email = update.Email;
                result.Role = role;
                result.FullName = update.FullName;
                result.ImgUrl = update.ImgUrl;
                result.Password = update.Password;

                _context.Accounts.Update(result);
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
        public async Task<IActionResult> DeleteAccount(string id)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id));
                if (account == null) return NotFound();

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }



        private bool AccountExists(string email, string id)
        {
            return (_context.Accounts?.Any(e => e.Email == email || e.Id == id)).GetValueOrDefault();
        }
    }
}

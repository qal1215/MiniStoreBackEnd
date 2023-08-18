using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly MiniStoreContext _context;
        public VouchersController(MiniStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        [EnableCors("default")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVouchers()
        {
            var voucherList = await _context.Vouchers.ToListAsync();
            if (voucherList == null) return NoContent();
            return Ok(voucherList);
        }
        [HttpGet]
        [EnableCors("default")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVouchersFor1Product(string productId)
        {
            var voucherList = await _context.Vouchers.Where(c => c.ProductId == productId).ToListAsync();
            if (voucherList == null) return NoContent();
            return Ok(voucherList);
        }
        [HttpPost("create")]
        [EnableCors("default")]
        public async Task<IActionResult> CreateVoucher([FromForm] VoucherCreate voucher)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == voucher.ProductId);
            if (product == null) return BadRequest("This product is not existed before");
            Voucher voucherToCreate = new Voucher
            {
                ProductId = voucher.ProductId,
                DiscountAmount = voucher.DiscountAmount,
                CreateTime = DateTime.Now,
                StartTime = voucher.StartTime,
                ExpectedEndTime = voucher.ExpectedEndTime,
                ActualEndTime = null,
                Status = voucher.Status,
                RemainingProducts = voucher.RemainingProducts
            };
            return Ok(voucherToCreate);
        }
    }
}

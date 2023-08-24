using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStore.Controllers
{
    [Route("api/vouchers")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public VouchersController(MiniStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [EnableCors("Default")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVouchers()
        {
            var voucherList = await _context.Vouchers.ToListAsync();
            if (voucherList == null) return NoContent();
            return Ok(voucherList);
        }

        [EnableCors("Default")]
        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVouchersFor1Product(string productId)
        {
            var voucherList = await _context.Vouchers.Where(c => c.ProductId == productId).ToListAsync();
            if (voucherList == null) return NoContent();
            return Ok(voucherList);
        }

        [EnableCors("Default")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateVoucher(VoucherCreate voucher)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == voucher.ProductId);
            if (product == null) return BadRequest(new { Message = "This product is not existed before" });
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
            await _context.Vouchers.AddAsync(voucherToCreate);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Voucher created successfully" });
        }

        [EnableCors("Default")]
        [HttpPut("endVoucher")]
        public async Task<IActionResult> EndVoucherManually(int voucherId) //quan ly muon end voucher som hon du tinh, khong can biet con` hang` hay k
        {
            var voucher = await _context.Vouchers.FirstOrDefaultAsync(c => c.Id == voucherId);
            if (voucher == null) return BadRequest(new { Message = "Voucher is not existed" });
            voucher.ActualEndTime = DateTime.Now;
            voucher.Status = false;
            await _context.SaveChangesAsync();
            string announce = String.Format("Finish voucher success");
            return Ok(new { Message = announce });
        }
    }
}

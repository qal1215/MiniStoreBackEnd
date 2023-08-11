using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public OrderController(MiniStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewOrder>>> GetAllOrder()
        {
            return null;
        }

        //[HttpPost("")]
        //public async Task<IActionResult> CreateOrder(Order create)
        //{
        //    var order = new Order
        //    {
        //        OrderId = create.OrderId,
        //        CreateDate = DateTime.Now,
        //        Amount = 0,
        //        CustomerName = create.CustomerName,
                
        //    };
        //}
    }
}

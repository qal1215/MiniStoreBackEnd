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
    public class CategoriesController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public CategoriesController(MiniStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("default")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            if (categories == null) return NoContent();
            return Ok(categories);
        }

        [HttpPut]
        [EnableCors("default")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            var result = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id);

            if (result == null) return NotFound();

            result.Name = category.Name;
            _context.Categories.Update(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }

    }
}

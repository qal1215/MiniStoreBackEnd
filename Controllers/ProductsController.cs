using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;

namespace MiniStoreRepository.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MiniStoreContext _context;

        public ProductsController(MiniStoreContext context)
        {
            _context = context;
        }

        [EnableCors("Default")]
        [HttpGet]
        public async Task<ActionResult<ViewProduct[]>> GetAllProducts()
        {
            var result = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ViewProduct
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Category.Name,
                    Stock = p.Stock,
                    Unit = p.Unit
                })
                .ToListAsync();

            return Ok(result);
        }

        [EnableCors("Default")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewProduct>> GetById(string id)
        {
            var result = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Id == id)
                .Select(p => new ViewProduct
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Category.Name,
                    Stock = p.Stock,
                    Unit = p.Unit
                })
                .FirstOrDefaultAsync();

            if (result == null) return NotFound();

            return Ok(result);
        }

        [EnableCors("Default")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (CheckExist(product.Id)) return BadRequest(new { Message = "Product is existed!" });

            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(product.Category));
                if (category == null)
                {
                    await _context.Categories.AddAsync(new Category
                    {
                        Name = product.Category!
                    });
                    await _context.SaveChangesAsync();
                    category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(product.Category));
                }

                var model = new Product
                {
                    Category = category!,
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Stock = product.Stock,
                    Unit = product.Unit
                };
                await _context.Products.AddAsync(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [EnableCors("Default")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, CreateProduct product)
        {
            if (!CheckExist(id)) return NotFound(new { Message = "Not found product!" });
            if (product == null || !id.Equals(product.Id)) return BadRequest();

            try
            {
                var oProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
                if (oProduct == null)
                {
                    return NotFound();
                }
                else
                {
                    var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(product.Category));
                    if (category == null)
                    {
                        await _context.Categories.AddAsync(new Category
                        {
                            Name = product.Category!
                        });
                        await _context.SaveChangesAsync();
                        category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(product.Category));
                    }

                    oProduct.Name = product.Name;
                    oProduct.Category = category!;
                    oProduct.Description = product.Description;
                    oProduct.ImageUrl = product.ImageUrl;
                    oProduct.Price = product.Price;
                    oProduct.Unit = product.Unit;
                    oProduct.Stock = product.Stock;
                    _context.Products.Update(oProduct);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [EnableCors("Default")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
                if (product == null) return NotFound();

                product.IsDeleted = true;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Deleted product id" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }



        private bool CheckExist(string id)
        {
            var product = _context.Products
                .Where(p => p.Id.Equals(id))
                .FirstOrDefault();

            return product != null;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCrudAPI.Models;

namespace ProductCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            if (_context.Products == null || _context.Products.Count() == 0)
            {
                return NoContent();
            }

            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product request)
        {
            if (request == null ||
                string.IsNullOrEmpty(request.Name) ||
                request.Price <= 0)
            {
                return BadRequest();
            }

            await _context.Products.AddAsync(request);
            await _context.SaveChangesAsync();

            // return Ok();
            return CreatedAtAction(nameof(Get), new { id = request.Id }, request);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product request)
        {
            if (request == null ||
                request.Id < 1 ||
                string.IsNullOrEmpty(request.Name) ||
                request.Price <= 0)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
    }
}

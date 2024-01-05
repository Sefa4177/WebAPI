using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.DTO;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    // localhost:5000/api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        // localhost:5000/api/products => GET
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products =  await _context.Products.Where(i => i.IsActive).Select(p => ProductToDTO(p)).ToListAsync();
            return Ok(products);
        }

        // localhost:5000/api/products/5 => GET
        [HttpGet("GetOneProduct/{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {   
            if(id == null)
            {
                return NotFound();
            }

            var p = await _context.Products.Where(i => i.ProductId == id).Select(p => ProductToDTO(p)).FirstOrDefaultAsync();

            if(p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        [Authorize]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            if(entity != null && entity.ProductId != 0 && entity.ProductName != "string" && entity.Price != 0)
            {
                _context.Products.Add(entity);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProduct),new { id = entity.ProductId }, entity);
            }
            return BadRequest(new {message = "Bütün alanlar eksiksiz doldurulmalıdır"});
            
        }

        // localhost:5000/api/products/5 => PUT
        [Authorize]
        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if(id != entity.ProductId)
            {
                return BadRequest();
            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }

            product.ProductName = entity.ProductName;
            product.Price = entity.Price;
            product.IsActive = entity.IsActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if(id == null)
            {
                return  NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();
        }
    
        private static ProductDTO ProductToDTO(Product p)
        {
            var entity = new ProductDTO();
            if(p != null) 
            {
                entity.ProductId = p.ProductId;
                entity.ProductName = p.ProductName;
                entity.Price = p.Price;
            }
            return entity;
        }
    }


}
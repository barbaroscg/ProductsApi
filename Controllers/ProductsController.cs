using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.DTO;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext _context;

        public ProductsController(ProductsDbContext context)
        {
            // _products = new List<Product>
            // {
            //     new Product { ProductId = 1 , ProductName = "IPhone 14", Price = 50000, IsActive = true},
            //     new Product { ProductId = 2 , ProductName = "IPhone 15", Price = 45000, IsActive = false},
            //     new Product { ProductId = 3 , ProductName = "IPhone 16", Price = 67000, IsActive = false},
            //     new Product { ProductId = 4 , ProductName = "IPhone 17", Price = 78000, IsActive = true}
            // };
            _context = context;
        }


        //http://localhost:5005/api/products => GET
        [HttpGet]
        public async Task<IActionResult> GetProducts(){
            //return _products == null ? new List<Product>() : _products;
            var products = await _context.
            Products.
            Select(p => new ProductDTO {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price
            }).
            ToListAsync();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var p = await _context.Products.
            Select(p => new ProductDTO {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price
            }).
            FirstOrDefaultAsync(x => x.ProductId == id);
            if(p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        [HttpPost]
         public async Task<IActionResult> CreateProduct(Product entity)
         {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = entity.ProductId}, entity);
         }


         [HttpPut("{id}")]
         public async Task<IActionResult> UpdateProduct(int id,Product entity)
         {
           if(id == null)
           {
            return BadRequest();
           }

           var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

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
            catch (Exception)
            {
                return NotFound();
                
            }
            return NoContent();
         }


         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteProduct(int id)
         {
           if(id == null)
           {
            return BadRequest();
           }

           var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
                
            }
            return NoContent();
         }


    }
}
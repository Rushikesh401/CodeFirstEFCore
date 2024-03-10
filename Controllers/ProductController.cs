using CodeFirstEFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace CodeFirstEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _dbContext;
        public ProductController(ProductDBContext productDBContext)
        {
                _dbContext = productDBContext;
            
        }
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
                 
        }
        [HttpGet("{id}")]
         public async Task<Product> GetProductById(int id)
        {
            return await  _dbContext.Products.FindAsync(id);
        
        }
        [HttpPost]

        public async Task<Product> AddProduct(Product product)
        { 
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;

        }
        [HttpDelete]
        public async Task<Product> DeleteProduct(int id)
        { 
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            { 
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
                return product;

            }
            return product;
        }
      
    }
}

using Microsoft.EntityFrameworkCore;
using Task2_Api.Data;
using Task2_Api.Models;

namespace Task2_Api.Services
{
    public class ProductsService : IProductsService
    {
        private AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            await _context.AddAsync(product);
            _context.SaveChangesAsync();
            return product;
        }

        public Product Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll(byte categotyid = 0)
        {
            return await _context.Products.Where(m => m.CategoryId == categotyid || categotyid == 0).Include(m => m.Category).ToListAsync();
             
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(m => m.Category).SingleOrDefaultAsync(g => g.ProductId == id);
        }

        public Product Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}

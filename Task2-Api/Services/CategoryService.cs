using Microsoft.EntityFrameworkCore;
using Task2_Api.Models;

namespace Task2_Api.Services
{
    public class CategoryService : ICategoriesService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category Category)
        {
            await _context.AddAsync(Category);
            _context.SaveChanges();
            return Category;
        }

        public Category Delete(Category Category)
        {
            _context.Update(Category);
            _context.SaveChanges();

            return Category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<Category> GetById(byte id)
        {
            return await _context.Categories.SingleOrDefaultAsync(m => m.CategoryId == id);
        }

        public Task<bool> IsValid(byte id)
        {
            return _context.Categories.AnyAsync(g => g.CategoryId == id);
        }

        public Category Update(Category Category)
        {
            _context.Update(Category);
            _context.SaveChanges();

            return Category;
        }
    }
}

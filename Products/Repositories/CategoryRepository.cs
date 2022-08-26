using Microsoft.EntityFrameworkCore;
using Products.Data.Models;
using Products.Data;
using Products.Interfaces;

namespace Products.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ProductsContext _context;
        public CategoryRepository(ProductsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetDetails(int id)
        {
            return await _context.Categories.Include(q => q.Products)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async override Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(q => q.Image).ToListAsync();
        }
    }
}

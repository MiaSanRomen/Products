using Microsoft.EntityFrameworkCore;
using Products.Data.Models;
using Products.Data;
using Products.Interfaces;

namespace Products.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        private readonly ProductsContext _context;
        public ProductsRepository(ProductsContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(q => q.Image).Include(q => q.Category).ToListAsync();
        }

        public async Task<List<Product>> GetSpecificAsync(string searchName)
        {
            return await _context.Products.Where(prod => prod.Name.ToLower().Contains(searchName.ToLower()))
                .Include(q => q.Category).Include(q => q.Image).ToListAsync();
        }

        public async override Task<Product> GetDetails(int id)
        {
            return await _context.Products.Include(q => q.Category)
                .FirstOrDefaultAsync(q => q.ProductId == id);
        }
    }
}

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
            return await _context.Products.Include(q => q.GeneralNote).Include(q => q.Category).Include(q => q.Image).ToListAsync();
        }
    }
}

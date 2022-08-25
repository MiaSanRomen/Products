using Microsoft.EntityFrameworkCore;
using Products.Data.Models;
using Products.Data;
using Products.Interfaces;

namespace Products.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ProductsContext context) : base(context)
        {

        }
    }
}

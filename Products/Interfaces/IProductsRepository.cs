using Products.Data.Models;
using System.Diagnostics.Metrics;

namespace Products.Interfaces
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetSpecificAsync(string searchName);
    }
}
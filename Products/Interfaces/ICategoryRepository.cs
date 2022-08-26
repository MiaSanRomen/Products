using Products.Data.Models;
using System.Diagnostics.Metrics;

namespace Products.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetDetails(int id);
    }
}
using Microsoft.EntityFrameworkCore;
using Products.Data.Models;
using Products.Data;
using Products.Interfaces;

namespace Products.Repositories
{
    public class GeneralNoteRepository : GenericRepository<GeneralNote>, IGeneralNoteRepository
    {
        public GeneralNoteRepository(ProductsContext context) : base(context)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Models;

namespace Products.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Еда"
                },
                new Category
                {
                    Id = 2,
                    Name = "Вкусности"
                },
                new Category
                {
                    Id = 3,
                    Name = "Вода"
                }
            );
        }
    }
}

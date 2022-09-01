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
                    CategoryId = 1,
                    Name = "Еда",
                    ImageId = 2,
                    Count = 2
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Вкусности",
                    ImageId = 7,
                    Count = 1
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Вода",
                    ImageId = 6,
                    Count = 1
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Без категории",
                    ImageId = 8,
                    Count = 0
                }
            );
        }
    }
}

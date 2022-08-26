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
                    Name = "Еда",
                    ImageId = 2,
                    Count = 2
                },
                new Category
                {
                    Id = 2,
                    Name = "Вкусности",
                    ImageId = 7,
                    Count = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Вода",
                    ImageId = 6,
                    Count = 1
                },
                new Category
                {
                    Id = 4,
                    Name = "Без категории",
                    ImageId = 8,
                    Count = 0
                }
            );
        }
    }
}

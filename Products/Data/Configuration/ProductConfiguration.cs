using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Models;

namespace Products.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Селедка",
                    Description = "Селедка соленая",
                    NoteCustom = "Пересоленая",
                    Price = 10000,
                    CategoryId = 1,
                    GeneralNoteId = 1,
                    ImageId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Тушенка",
                    Description = "Тушенка говяжая",
                    NoteCustom = "Жилы",
                    Price = 20000,
                    CategoryId = 1,
                    GeneralNoteId = 2,
                    ImageId = 4
                },
                new Product
                {
                    Id = 3,
                    Name = "Сгущенка",
                    Description = "В банках",
                    NoteCustom = "Вкусная",
                    Price = 30000,
                    CategoryId = 2,
                    GeneralNoteId = 3,
                    ImageId = 5
                },
                new Product
                {
                    Id = 4,
                    Name = "Квас",
                    Description = "В бутылках",
                    NoteCustom = "Теплый",
                    Price = 15000,
                    CategoryId = 3,
                    GeneralNoteId = 4,
                    ImageId = 3
                }
            );
        }
    }
}

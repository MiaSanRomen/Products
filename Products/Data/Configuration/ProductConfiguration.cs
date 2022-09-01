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
                    ProductId = 1,
                    Name = "Селедка",
                    Description = "Селедка соленая",
                    NoteCustom = "Пересоленая",
                    Price = 10000,
                    CategoryId = 1,
                    GeneralNote = "Акция",
                    ImageId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Тушенка",
                    Description = "Тушенка говяжая",
                    NoteCustom = "Жилы",
                    Price = 20000,
                    CategoryId = 1,
                    GeneralNote = "Вкусная",
                    ImageId = 4
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Сгущенка",
                    Description = "В банках",
                    NoteCustom = "Вкусная",
                    Price = 30000,
                    CategoryId = 2,
                    GeneralNote = "С ключом",
                    ImageId = 5
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Квас",
                    Description = "В бутылках",
                    NoteCustom = "Теплый",
                    Price = 15000,
                    CategoryId = 3,
                    GeneralNote = "Вятский",
                    ImageId = 3
                }
            );
        }
    }
}

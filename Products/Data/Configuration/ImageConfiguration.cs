using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Models;

namespace Products.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    Id = 1,
                    Path = "/images/fish.jfif"
                },
                new Image
                {
                    Id = 2,
                    Path = "/images/food.jpg"
                },
                new Image
                {
                    Id = 3,
                    Path = "/images/kvas.jpg"
                },
                new Image
                {
                    Id = 4,
                    Path = "/images/meat.jpg"
                },
                new Image
                {
                    Id = 5,
                    Path = "/images/sugarmilk.jpg"
                },
                new Image
                {
                    Id = 6,
                    Path = "/images/water.jpg"
                },
                new Image
                {
                    Id = 7,
                    Path = "/images/yummy.jpg"
                },
                new Image
                {
                    Id = 8,
                    Path = "/images/food-unknown.jpg"
                }
            );
        }
    }
}

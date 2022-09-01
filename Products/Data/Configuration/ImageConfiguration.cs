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
                    ImageId = 1,
                    Path = "/images/fish.jfif"
                },
                new Image
                {
                    ImageId = 2,
                    Path = "/images/food.jpg"
                },
                new Image
                {
                    ImageId = 3,
                    Path = "/images/kvas.jpg"
                },
                new Image
                {
                    ImageId = 4,
                    Path = "/images/meat.jpg"
                },
                new Image
                {
                    ImageId = 5,
                    Path = "/images/sugarmilk.jpg"
                },
                new Image
                {
                    ImageId = 6,
                    Path = "/images/water.jpg"
                },
                new Image
                {
                    ImageId = 7,
                    Path = "/images/yummy.jpg"
                },
                new Image
                {
                    ImageId = 8,
                    Path = "/images/food-unknown.jpg"
                }
            );
        }
    }
}

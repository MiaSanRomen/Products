using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Models;

namespace Products.Configuration
{
    public class GeneralNoteConfiguration : IEntityTypeConfiguration<GeneralNote>
    {
        public void Configure(EntityTypeBuilder<GeneralNote> builder)
        {
            builder.HasData(
                new GeneralNote
                {
                    Id = 1,
                    Name = "Акция"
                },
                new GeneralNote
                {
                    Id = 2,
                    Name = "Вкусная"
                },
                new GeneralNote
                {
                    Id = 3,
                    Name = "С ключом"
                },
                new GeneralNote
                {
                    Id = 4,
                    Name = "Вятский"
                }
            );
        }
    }
}

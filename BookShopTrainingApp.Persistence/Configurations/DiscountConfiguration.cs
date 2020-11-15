using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Discount);
            builder.HasKey(x => x.Id);
            builder.HasData(
                new Discount { Id = 1, Rate = 5 },
                new Discount { Id = 2, Rate = 10 },
                new Discount { Id = 3, Rate = 25 },
                new Discount { Id = 4, Rate = 50 }
                );
        }
    }
}
using BookShopTrainingApp.Core;
using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Price);
            builder.HasData(
                new Price { Id = 1, Amount = 9.99m, Currency = Currencies.EUR },
                new Price { Id = 2, Amount = 13.99m, Currency = Currencies.EUR },
                new Price { Id = 3, Amount = 15.99m, Currency = Currencies.EUR }
                );
        }
    }
}
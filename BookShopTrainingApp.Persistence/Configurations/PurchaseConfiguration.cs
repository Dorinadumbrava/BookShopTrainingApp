using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Book).WithMany(x => x.Purchases);
            builder.HasOne(x => x.Price).WithMany(x => x.Purchases);
            builder.HasOne(x => x.Discount).WithMany(x => x.Purchases);
        }
    }
}
using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class BookDiscountConfiguration : IEntityTypeConfiguration<BookDiscount>
    {
        public void Configure(EntityTypeBuilder<BookDiscount> builder)
        {
            builder.HasOne(x => x.Discount)
                .WithMany(x => x.Books);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Discounts);
            builder.HasKey(t => new { t.DiscountId, t.BookId });
            builder.HasData(
                new BookDiscount { BookId = 4, DiscountId = 3 }
                );
        }
    }
}
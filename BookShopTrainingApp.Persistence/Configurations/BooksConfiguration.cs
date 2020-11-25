using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(x => x.Authors)
                .WithOne(x => x.Book);
            builder.HasOne(x => x.Discount)
                .WithMany(x => x.Books);
            builder.HasOne(x => x.Price)
                .WithMany(x => x.Books);
            builder.HasKey(x => x.Id);
            builder.HasData(
                new Book { Id = 1, Name = "Adeventures of a tired Programmer", Description = "A long and funny day", PriceId = 3},
                new Book { Id = 2, Name = "How my cat concuered the world", Description = "about a cat", PriceId = 1},
                new Book { Id = 3, Name = "Fantastic beasts and where you find them", 
                    Description = "A guide to people you can meet in your life", PriceId = 2, DiscountId = 3},
                new Book { Id = 4, Name = "Just do it tomorrow", 
                    Description = "How to make half of your tasks for the sprint in the last day before codeFreeze", PriceId = 2},
                new Book { Id = 5, Name = "Coffee and memes", Description = "A guide of office survival", PriceId = 3}
                );
            builder.OwnsOne(x => x.Stock).HasData(
                new { BookId = 1, Amount = 10},
                new { BookId = 2, Amount = 1},
                new { BookId = 3, Amount = 6},
                new { BookId = 4, Amount = 20},
                new { BookId = 5, Amount = 5}
                );
        }
    }
}
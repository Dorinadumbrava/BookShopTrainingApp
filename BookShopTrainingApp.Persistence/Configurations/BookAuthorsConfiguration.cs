using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class BookAuthorsConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Authors);
            builder.HasKey(t => new { t.AuthorId, t.BookId });
            builder.HasData(
                new BookAuthor {BookId = 1, AuthorId = 2},
                new BookAuthor {BookId = 2, AuthorId = 2},
                new BookAuthor {BookId = 3, AuthorId = 1},
                new BookAuthor {BookId = 4, AuthorId = 3},
                new BookAuthor {BookId = 5, AuthorId = 3},
                new BookAuthor {BookId = 5, AuthorId = 4}
                );
        }
    }
}
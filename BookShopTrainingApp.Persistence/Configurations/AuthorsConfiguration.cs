using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Author);
            builder.HasKey(x => x.Id);
            builder.HasData(
                new Author { Id = 1, Name = "Hustem", Biography = "A long long Biography", Surname = "Mriana" },
                new Author { Id = 2, Name = "Abant", Biography = "Anothe long long Biography", Surname = "Lidia" },
                new Author { Id = 3, Name = "Leroy", Biography = "Once more a long long Biography", Surname = "John" },
                new Author { Id = 4, Name = "Bailyk", Biography = "A short Biography", Surname = "Joseph" }
                );
        }
    }
}
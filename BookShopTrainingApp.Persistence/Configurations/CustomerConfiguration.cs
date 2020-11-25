using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopTrainingApp.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Purchases).WithOne(x => x.Customer);
            builder.HasData(
                new Customer { Id = 1, Name = "Mihaila", Surname = "Andreea" },
                new Customer { Id = 2, Name = "Maximenco", Surname = "Valeriu" },
                new Customer { Id = 3, Name = "Andronache", Surname = "Madalina" },
                new Customer { Id = 4, Name = "Botgros", Surname = "Simeon" }
                );
        }
    }
}
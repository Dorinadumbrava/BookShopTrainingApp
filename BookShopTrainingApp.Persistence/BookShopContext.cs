using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookShopTrainingApp.Persistence
{
    public class BookShopContext : DbContext, IBookShopContext
    {
        public BookShopContext()
        {

        }
        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
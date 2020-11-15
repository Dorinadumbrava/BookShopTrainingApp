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
        public virtual DbSet<Author> Authors { get; }
        public virtual DbSet<BookAuthor> BookAuthors { get; }
        public virtual DbSet<BookDiscount> BookDiscounts { get; }
        public virtual DbSet<Discount> Discounts { get; }
        public virtual DbSet<Price> Prices { get; }
        public virtual DbSet<Purchase> Purchases { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
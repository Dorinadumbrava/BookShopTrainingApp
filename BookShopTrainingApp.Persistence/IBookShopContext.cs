using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Persistence
{
    public interface IBookShopContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<Price> Prices { get; set; }
        DbSet<Purchase> Purchases { get; set; }
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
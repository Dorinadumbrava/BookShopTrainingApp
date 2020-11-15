using BookShopTrainingApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookShopTrainingApp.Persistence
{
    public interface IBookShopContext
    {
        DbSet<Author> Authors { get; }
        DbSet<BookAuthor> BookAuthors { get; }
        DbSet<BookDiscount> BookDiscounts { get; }
        DbSet<Book> Books { get; set; }
        DbSet<Discount> Discounts { get; }
    }
}
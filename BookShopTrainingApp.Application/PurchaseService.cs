using BookShopTrainingApp.Persistence;
using System;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application
{
    public class PurchaseService
    {
        private readonly BookShopContext context;

        public PurchaseService(BookShopContext context)
        {
            this.context = context;
        }

        public async Task BuyBook(Guid bookId, Guid customerId)
        {
            var book = this.context.Books.Find(bookId);
        }
    }
}
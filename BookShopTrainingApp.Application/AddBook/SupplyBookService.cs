using BookShopTrainingApp.Core;
using BookShopTrainingApp.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.AddBook
{
    public class SupplyBookService : ISupplyBookService
    {
        private readonly IBookShopContext context;

        public SupplyBookService(IBookShopContext context)
        {
            this.context = context;
        }

        public async Task<AddBookActionResult> AddBook(AddBookDto bookDto, CancellationToken cancellationToken)
        {
            var authorsInDb = GetAuthors(bookDto.Authors);
            var price = bookDto.Price.GetFromDataBase(context);
            bookDto.AddToDatabase(context, price, authorsInDb.Authors);
            int id = 0;
            try
            {
                id = await context.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception ex)
            {
                return new AddBookActionResult(ActionStatus.Failure, ex.Message);
            }
            if (id == 0)
            {
                return new AddBookActionResult(ActionStatus.Failure, "Book not added in Database");
            }
            return new AddBookActionResult(ActionStatus.Success, new BookModel(bookDto, id));
        }

        private AuthorsDto GetAuthors(IEnumerable<AuthorDto> authors)
        {
            var authorsindb = new AuthorsDto();
            authorsindb.AddAuthors(authors, context);
            return authorsindb;
        }
    }
}
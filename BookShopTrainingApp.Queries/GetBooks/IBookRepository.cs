using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Queries.GetBooks
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetAll(CancellationToken cancellationToken);
    }
}
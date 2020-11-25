using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.AddBook
{
    public interface ISupplyBookService
    {
        Task<AddBookActionResult> AddBook(AddBookDto bookDto, CancellationToken cancellationToken);
    }
}
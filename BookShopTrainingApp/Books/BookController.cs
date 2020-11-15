using BookShopTrainingApp.Queries.GetBooks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Web.Books
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> Get()
        {
            return await bookRepository.GetAll(new CancellationToken());
        }
    }
}
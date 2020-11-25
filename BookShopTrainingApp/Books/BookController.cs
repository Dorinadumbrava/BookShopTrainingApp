using BookShopTrainingApp.Application.AddBook;
using BookShopTrainingApp.Core;
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
        private readonly ISupplyBookService bookService;

        public BookController(IBookRepository bookRepository, ISupplyBookService bookService)
        {
            this.bookRepository = bookRepository;
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> Get()
        {
            return await bookRepository.GetAll(new CancellationToken());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await bookService.AddBook(bookDto, new CancellationToken());

            if (result.Status == ActionStatus.Success)
            {
                return Ok(result.Book);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
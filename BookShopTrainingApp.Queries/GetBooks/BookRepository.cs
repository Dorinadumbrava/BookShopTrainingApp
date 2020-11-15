using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopTrainingApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Queries.GetBooks
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookShopContext context;
        private readonly IMapper mapper;

        public BookRepository(IBookShopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<List<BookDto>> GetAll(CancellationToken cancellationToken)
        {
            return this.context.Books
                .Include(x => x.Authors).ThenInclude(x=>x.Author)
                .ProjectTo<BookDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
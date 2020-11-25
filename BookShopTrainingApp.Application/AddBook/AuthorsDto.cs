using BookShopTrainingApp.Domain;
using BookShopTrainingApp.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace BookShopTrainingApp.Application.AddBook
{
    internal class AuthorsDto
    {
        public AuthorsDto()
        {
        }

        public AuthorsDto(List<Author> authors)
        {
            Authors = authors;
        }

        public IEnumerable<Author> Authors { get; set; }

        internal void AddAuthors(IEnumerable<AuthorDto> authors, IBookShopContext context)
        {
            List<Author> authorsindb = new List<Author>();
            Authors = authors.Select(x => x.GetFromDatabase(context)).ToList();
        }
    }
}
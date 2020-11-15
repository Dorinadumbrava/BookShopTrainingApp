using System.Collections.Generic;

namespace BookShopTrainingApp.Queries.GetBooks
{
    public class BookDto
    {
        public string Name { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
using System.Collections.Generic;

namespace BookShopTrainingApp.Application.AddBook
{
    public class BookModel
    {

        public BookModel(AddBookDto bookDto, int id)
        {
            Id = id;
            Name = bookDto.Name;
            Description = bookDto.Description;
            Authors = bookDto.Authors;
            Price = bookDto.Price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public PriceDto Price { get; set; }
    }
}
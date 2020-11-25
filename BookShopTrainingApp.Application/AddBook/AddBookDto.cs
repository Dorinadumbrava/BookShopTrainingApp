using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookShopTrainingApp.Domain;
using BookShopTrainingApp.Persistence;

namespace BookShopTrainingApp.Application.AddBook
{
    public class AddBookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [MinLength(1)]
        public IEnumerable<AuthorDto> Authors { get; set; }
        [Required]
        public PriceDto Price { get; set; }
        [Range(1, 100)]
        public int Ammount { get; set; }

        internal void AddToDatabase(IBookShopContext context, Price price, IEnumerable<Author> authors)
        {
            var book = context.Books.FirstOrDefault(x => x.Name == this.Name && x.Description == this.Description);

            if (book == null)
            {
                var newBook = new Book(this.Name, this.Description, price, 
                    new Stock(this.Ammount), authors);
                context.Books.Add(newBook);
            }
            book.Stock = new Stock(book.Stock.Amount + this.Ammount);
        }
    }
}
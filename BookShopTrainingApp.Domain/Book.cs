using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Book
    {
        public Book() { }
        public Book(string name, string description, Price price, Stock stock, IEnumerable<Author> authors)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Authors = GetAuthors(authors);
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookAuthor> Authors { get; set; }
        public int? PriceId { get; set; }
        public Price Price { get; set; }
        public Stock Stock { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }

        private IEnumerable<BookAuthor> GetAuthors(IEnumerable<Author> authors)
        {
            var bookAuthors = new List<BookAuthor>();
            foreach (var author in authors)
            {
                bookAuthors.Add(new BookAuthor() { Author = author, Book = this});
            }
            return bookAuthors;
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookAuthor> Authors { get; set; }
        public int? PriceId { get; set; }
        public Price Price { get; set; }
        public Stock Stock { get; set; }
        public IEnumerable<BookDiscount> Discounts { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
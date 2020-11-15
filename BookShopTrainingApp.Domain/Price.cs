using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Currencies Currency { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookShopTrainingApp.Domain
{
    public class Discount
    {
        public Discount() { }

        public Discount(List<Discount> discounts)
        {
            var activeDiscounts = discounts.Where(x => x.StartDate < DateTime.Today && x.EndDate >= DateTime.Today).ToList();
            Rate = activeDiscounts.Sum(x => x.Rate);
            Description = "Discount summed at purchase";
        }

        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
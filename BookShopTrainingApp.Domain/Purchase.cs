using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Purchase
    {
        [Key]
        public int? Id { get; set; }

        public int? BookId { get; set; }
        public Book Book { get; set; }
        public DateTime PurcahseTime { get; set; }
        public int? PriceId { get; set; }
        public Price Price { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
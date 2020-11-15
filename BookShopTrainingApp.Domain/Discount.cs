using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Discount
    {
        public Discount()
        {
        }

        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookDiscount> Books { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
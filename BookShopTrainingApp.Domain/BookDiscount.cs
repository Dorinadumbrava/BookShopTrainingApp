﻿namespace BookShopTrainingApp.Domain
{
    public class BookDiscount
    {
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
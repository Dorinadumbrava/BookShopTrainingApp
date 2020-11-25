using System;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public class PurchaseDto
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchasedOn { get; set; }
        public PriceDto Price { get; set; }
        public int Discount { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public class AddPurchaseDto
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}

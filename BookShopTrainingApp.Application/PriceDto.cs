using System;
using System.Linq;
using BookShopTrainingApp.Core;
using BookShopTrainingApp.Domain;
using BookShopTrainingApp.Persistence;

namespace BookShopTrainingApp.Application
{
    public class PriceDto
    {

        public decimal Ammount { get; set; }
        public Currencies Currency { get; set; }

        internal Price GetFromDataBase(IBookShopContext context)
        {
            var price = context.Prices.FirstOrDefault(x => x.Amount == this.Ammount && x.Currency == this.Currency);
            if (price == null)
            {
                price = new Price(this.Ammount, this.Currency);
                context.Prices.Add(price);
            }
            return price;
        }
    }
}
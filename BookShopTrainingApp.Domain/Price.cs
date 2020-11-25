using BookShopTrainingApp.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Price
    {
        private decimal _amount;
        public Price() { }

        public Price(decimal amount, Currencies currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public int Id { get; set; }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value >= 0)
                {
                    _amount = value;
                }
                else
                {
                    _amount = 0;
                }
            }
        }

        public Currencies Currency { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
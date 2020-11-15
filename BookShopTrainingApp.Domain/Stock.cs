using System.Collections.Generic;

namespace BookShopTrainingApp.Domain
{
    public class Stock: ValueObject
    {
        private Stock() { }
        public Stock(int amount)
        {
            if (amount > 0 || amount < 100)
            {
                Amount = amount;
            }
        }
        public int? BookId { get; set; }
        public int Amount { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
        }
    }
}
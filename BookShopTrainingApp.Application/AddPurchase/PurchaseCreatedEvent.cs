using BookShopTrainingApp.Domain;
using MediatR;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public class PurchaseCreatedEvent : INotification
    {
        public PurchaseCreatedEvent(string email, string book, Price price)
        {
            CustomerEmail = email;
            BookName = book;
            Price = price;
        }
        public string CustomerEmail { get; set; }
        public string BookName { get; set; }
        public Price Price { get; set; }
    }
}
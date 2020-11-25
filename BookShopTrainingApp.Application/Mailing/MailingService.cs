using BookShopTrainingApp.Application.AddPurchase;
using BookShopTrainingApp.Core.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.Mailing
{
    public class MailingService : IMailingService, INotificationHandler<PurchaseCreatedEvent>
    {
        private readonly IMailWrapper mailWrapper;

        public MailingService(IMailWrapper mailWrapper)
        {
            this.mailWrapper = mailWrapper;
        }

        public Task Handle(PurchaseCreatedEvent notification, CancellationToken cancellationToken)
        {
            var email = new EmailModel(notification.CustomerEmail,
                $"You have purchased {notification.BookName} for {notification.Price.Amount} {notification.Price.Currency.ToString()}");
            try
            {
                return mailWrapper.Send(email);
            }
            catch(MailServerNotReachedException ex)
            {
                //here should be a speciffic handler for the error
                throw ex;
            }
            catch (Exception ex)
            {
                //here we handle the generic exceptions
                throw ex;
            }
        }
    }
}
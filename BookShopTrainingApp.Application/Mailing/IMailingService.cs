using BookShopTrainingApp.Application.AddPurchase;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.Mailing
{
    public interface IMailingService
    {
        Task Handle(PurchaseCreatedEvent notification, CancellationToken cancellationToken);
    }
}
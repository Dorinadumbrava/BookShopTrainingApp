using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public interface IPurchaseService
    {
        Task<CreatePurchaseResult> BuyBook(AddPurchaseDto purchaseDto, CancellationToken cancellationToken);
    }
}
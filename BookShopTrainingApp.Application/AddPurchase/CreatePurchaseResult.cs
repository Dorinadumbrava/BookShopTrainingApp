using BookShopTrainingApp.Core;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public class CreatePurchaseResult
    {
        public CreatePurchaseResult(ActionStatus status, string message)
        {
            Status = status;
            ErrorMessage = message;
        }

        public CreatePurchaseResult(ActionStatus status, PurchaseDto purchase)
        {
            Status = status;
            Purchase = purchase;
        }

        public ActionStatus Status { get; }
        public PurchaseDto Purchase { get; }
        public string ErrorMessage { get;}
    }
}
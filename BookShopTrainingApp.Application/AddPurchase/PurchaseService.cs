using AutoMapper;
using BookShopTrainingApp.Core;
using BookShopTrainingApp.Domain;
using BookShopTrainingApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IBookShopContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PurchaseService(IBookShopContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<CreatePurchaseResult> BuyBook(AddPurchaseDto purchaseDto, CancellationToken cancellationToken)
        {
            var book = await context.Books.Include(x => x.Price).Include(x => x.Discount).Where(x => x.Id == purchaseDto.BookId).FirstOrDefaultAsync();
            var customer = context.Customers.Find(purchaseDto.CustomerId);
            if (customer == null)
            {
                return new CreatePurchaseResult(ActionStatus.Failure, "Customer not found");
            }
            if (book == null || customer == null)
            {
                return new CreatePurchaseResult(ActionStatus.Failure, "Book not found");
            }
            int? discountId = null;
            if (book.Discount != null)
            {
                discountId = book.Discount.Id;
            }
            var purchase = new Purchase
                (purchaseDto.BookId, purchaseDto.PurchaseTime, book.Price.Id, discountId, purchaseDto.CustomerId);
            context.Purchases.Add(purchase);

            await context.SaveChangesAsync();
            var purchaseEvent = new PurchaseCreatedEvent(customer.Email, book.Name, book.Price);
            await mediator.Publish(purchaseEvent, cancellationToken);
            return new CreatePurchaseResult(ActionStatus.Success, mapper.Map<PurchaseDto>(purchase));
        }
    }
}
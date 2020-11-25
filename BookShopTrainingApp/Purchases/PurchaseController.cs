using BookShopTrainingApp.Application.AddPurchase;
using BookShopTrainingApp.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Web.Purchases
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPurchaseDto purchaseDto)
        {
            var result = await purchaseService.BuyBook(purchaseDto, new CancellationToken());
            if (result.Status == ActionStatus.Failure)
            {
                return BadRequest();
            }
            return Ok(result.Purchase);
        }
    }
}